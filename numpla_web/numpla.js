/*
    ナンプレ(web版)

    作成日 : 2025/5/20
    作成者 : T.Tsuji

    仕様

    (1) 画面
        上部に、ゲーム盤面(9行×9列)を表示
            マスの色->白:空き、赤:誤り、緑:数字あり(通常)、水色:数字あり(次の手)
        中部に、次の手と次の手選択肢を表示
            マスの色->白:空き、赤:誤り、水色:次の手、灰:完了
        下部に、操作盤(戻るボタン、リスタートボタン、(難易度別)開始ボタン)を表示

    (2) 処理
        初期処理:画面を表示(ゲーム盤面の数字無し)
        開始ボタンでゲームを作成(仕様は後述)し、表示する。
        次の手選択肢クリックで、次の手を選択する。
        ゲーム盤面クリックで、次の手を盤面にセットまたはクリア
         a.初期盤面で空きのマスのみ次の手をセットまたはクリアできる。
         b.マスが次の手と同じ数字の場合は、マスをクリア、
         c.その他の時は次の手をセット
        全マスが誤りなく埋まったら終了

    (3) 誤り判定
        各行、各列に同じ数字が２回以上、出現する場合、誤り。
        また、3行×3列のブロック内に同じ数字が２回以上、出現する場合、誤り。

    (4) ゲーム盤面作成仕様
        a.完成された正しい盤面を作成する
        b.希望する難易度になるまで以下を繰り返す
          マスをランダムに削除する。
            削除するたびに「解が一意か」チェックし
            解が一意であればそのまま削除を確定する。
            そうでなければ戻す。

*/

'use strict';

//グローバル変数
const BOARD_SIZE = 9;
var g_gameBoard;        // ゲーム盤面
var g_backupBoard;      // バックアップ盤面
var g_strLevel = "";    // 難易度
var g_nextMove = 0;      // 次の手
var g_Undo = [];        // undoリスト




//
// Undoリストをクリアする(初期化)
//
function numpla_ClearUndo() {
    g_Undo = [];    // undoリスト
}

// 次の手(num)が指定されたマス(row, col)に置けるかチェックする
// return : false -> 置けない, true -> 置ける
function numpla_isValid(board, row, col, num) {
    //同じ列にnumと同じ数字がある場合は、置けない
    for (let row1 = 0; row1 < BOARD_SIZE; row1++) {
        if (row1 != row && board[row1][col] === num) {
            return false;
        }
    }
    //同じ行にnumと同じ数字がある場合は、置けない
    for (let col1 = 0; col1 < BOARD_SIZE; col1++) {
        if (col1 != col && board[row][col1] === num) {
            return false;
        }
    }

    // 3×3のブロックにnumと同じ数字がある場合は、置けない
    const startRow = 3 * Math.floor(row / 3);
    const startCol = 3 * Math.floor(col / 3);
    for (let row1 = 0; row1 < 3; row1++) {
        const row2 = startRow + row1;
        for (let col1 = 0; col1 < 3; col1++) {
            const col2 = startCol + col1;
            if (row2 != row && col2 != col && board[row2][col2] === num) {
                return false;
            }
        }
    }
    //置ける
    return true;
}

// ゲーム盤面から空のマスを探す
// return : 見つかった時[row, col], 見つからなかったとき null
function numpla_findEmptyCell(board) {
    for (let row = 0; row < BOARD_SIZE; row++) {
        for (let col = 0; col < BOARD_SIZE; col++) {
            if (board[row][col] === 0) {
                return [row, col];
            }
        }
    }
    return null;
}

// ナンプレを解く (with option to count solutions)
//return :
// countSolutionsがfalseの場合
//  true : 完了(解けた)  false : 解けない
// countSolutionsがtrueの場合
//  1以上 : 解の数(1:正規)  0 : 解けない

function numpla_solve(board, countSolutions = false, maxSolutions = 2) {
    //空きマスを探す
    const emptyCell = numpla_findEmptyCell(board);
    //空きマスが無ければ、完了(OK)
    if (!emptyCell) {
        return countSolutions ? 1 : true;
    }

    //空きマスに数値をセットして再帰的にナンプレを解く
    const [row, col] = emptyCell;
    let totalSolutions = 0;

    for (let num = 1; num <= BOARD_SIZE; num++) {
        //空きマスに数値をセット
        if (numpla_isValid(board, row, col, num)) {
            board[row][col] = num;
            //再帰的にナンプレを解く
            const result = numpla_solve(board, countSolutions, maxSolutions);
            if (countSolutions) {
                if (result) {
                    //解けた場合は、OK
                    totalSolutions += result;
                    if (totalSolutions >= maxSolutions) {
                        break;
                    }
                }
            } else {
                if (result) {
                    //解けた場合は、OK
                    return true;
                }
            }
            //解けなかった場合は、戻す
            board[row][col] = 0;
        }
    }

    return countSolutions ? totalSolutions : false;
}

//完成版のゲーム盤面を作成する
function numpla_generateCompleteBoard() {
    // 空(0要素)のゲーム盤面(9×9)を作る
    const completeBoard = Array.from({ length: BOARD_SIZE }, () => Array(BOARD_SIZE).fill(0));
    // 1～9の数値列を作る
    const baseNumbers = Array.from({ length: BOARD_SIZE }, (_, i) => i + 1);

    //完成版のゲーム盤面に数値を埋める(再帰)
    function numpla_fillboard() {
        //空のマスを探す。空のマスが無ければ完成。
        const emptyCell = numpla_findEmptyCell(completeBoard);
        if (!emptyCell) {
            return true;
        }

        const [row, col] = emptyCell;
        //1～9の数値列をかき混ぜる
        const shuffledNumbers = baseNumbers.sort(() => Math.random() - 0.5);
        for (const num of shuffledNumbers) {
            //指定されたマスに置けるかチェックする
            if (numpla_isValid(completeBoard, row, col, num)) {
                //置ける場合は、次の数字(階層)を試す
                completeBoard[row][col] = num;
                if (numpla_fillboard()) {
                    return true;
                }
                //置けない場合は、戻す。(別の数字を試す)
                completeBoard[row][col] = 0;
            }
        }
        return false;
    }

    //ゲーム盤面に数値を埋める
    numpla_fillboard();
    return completeBoard;
}


// ゲーム盤面の複製を作る
function numpla_dupBoard(board) {
    const result = [];
    for (const rec of board) {
        result.push([...rec]);
    }
    return result;
}

//
//完成ゲーム盤面から、単一の解がある状態を保持したまま、数字を削除して、問題ゲーム盤面を作成する。
//
function numpla_removeNumbers(board, tryCount = 50) {
    //完成ゲーム盤面から問題ゲーム盤面を作る
    const workBoard = numpla_dupBoard(board);
    while (tryCount > 0) {
        //問題ゲーム盤面の空きにするマスを選ぶ(ランダム)
        const row = Math.floor(Math.random() * BOARD_SIZE);
        const col = Math.floor(Math.random() * BOARD_SIZE);
        //すでに空きの場合、別のマスへ
        if (workBoard[row][col] === 0) {
            continue;
        }

        //マスを空きにしてみて、解が1つだけ見つかるか試行する。
        //見つかったら、次の手へ。見つからなかったら、戻す。
        {
            const backupNumber = workBoard[row][col];
            workBoard[row][col] = 0;
            //試行用のゲーム盤面を作る
            const boardCheck = numpla_dupBoard(workBoard);
            const solutions = numpla_solve(boardCheck, true);
            if (solutions !== 1) {
                workBoard[row][col] = backupNumber; // 見つからなかったら、戻す。
            }
        }
        tryCount--;
    }

    //作成したゲーム盤面を返す
    return workBoard;
}

//
//ゲーム盤面を初期化
//
function numpla_initBoard() {
    //tableにセット
    const ui_board = document.getElementById("numpla_board");
    for (let row = 0; row < BOARD_SIZE; row++) {
        let tr = ui_board.rows[row];
        for (let col = 0; col < BOARD_SIZE; col++) {
            //マスごとにイベント処理をセット
            let td = tr.cells[col];
            td.addEventListener("click", numpla_onClickBoard)
        }
    }
}

//
//ゲーム盤面を表示
//
function numpla_showBoard() {
    //tableにセット
    const ui_board = document.getElementById("numpla_board");
    for (let row = 0; row < BOARD_SIZE; row++) {
        let tr = ui_board.rows[row];
        for (let col = 0; col < BOARD_SIZE; col++) {
            //マスごとにスタイルと内容をセット
            let td = tr.cells[col];
            let td_className = "numpla_board_complete"; //完成マス
            let num = g_gameBoard[row][col];
            if (num == 0) {
                num = "・";
                td_className = "numpla_board_empty";    //空のマス
            }
            else {
                if (g_backupBoard[row][col] != 0) {
                    td_className = "numpla_board_base"    //初期の盤面のマス
                }
                if (num == g_nextMove) {
                    td_className = "numpla_board_selected";
                }
                let result = numpla_isValid(g_gameBoard, row, col, num);
                if (!result) {
                    td_className = "numpla_board_error";    //誤りのマス
                }
            }
            td.textContent = num;
            td.className = td_className;
        }
    }

}

//盤面クリック時の処理
function numpla_onClickBoard(e) {
    //マスを特定
    let row = this.parentNode.rowIndex;
    let col = this.cellIndex;
    if (g_nextMove != 0 && g_backupBoard[row][col] == 0) {
        //初期盤面で空きのマスのみ次の手をセットまたはクリアできる。
        let oldMove = g_gameBoard[row][col];
        let newMove = g_nextMove;
        if (oldMove == g_nextMove) {
            //２回目はマスをクリア
            newMove = 0;
        }
        //マスに設定
        g_gameBoard[row][col] = newMove;
        //undo用
        g_Undo.push(row, col, g_nextMove, oldMove)
        //ゲーム盤面を表示
        numpla_showBoard();
        //次の手選択肢のマスを表示
        numpla_showNumbers();
        //終了チェック
        if (numpla_checkFinished()) {
            numpla_ClearUndo(); //Undoリストをクリアする
            setTimeout(function () {
                alert("成功です!!")
            }, 1);
        }
    }
}

//終了チェック
function numpla_checkFinished() {
    for (let col = 0; col < BOARD_SIZE; col++) {
        let num = col + 1;
        let count = numpla_countNumber(g_gameBoard, num);
        if (count != BOARD_SIZE) {
            return (false);
        }
    }
    return (true);
}

//
//次の手選択肢のマスをクリックしたときの処理
//(次の手をセットする)
//
function numpla_onClickNumber(e) {
    //次の手
    //console.log(this);
    g_nextMove = this.innerText - 0;

    //ゲーム盤面表示
    numpla_showBoard()
    //次の手選択肢のマスを表示
    numpla_showNumbers();
}

//
//次の手選択肢のマスを設定
//
function numpla_initNumbers() {
    //tableにセット
    const tableNumbers = document.getElementById("numpla_numbers");
    let tr = tableNumbers.rows[0];
    for (let col = 0; col < BOARD_SIZE; col++) {
        let td = tr.cells[col];
        td.addEventListener("click", numpla_onClickNumber)
    }

}

//
//ゲーム盤面の数字の数を数える
//return : 誤りの場合は -1、OKの場合は、0以上
//
function numpla_countNumber(workBoard, num) {
    let countAll = 0;
    //行ごとのチェック
    for (let row = 0; row < BOARD_SIZE; row++) {
        let count1 = 0;
        for (let col = 0; col < BOARD_SIZE; col++) {
            if (workBoard[row][col] === num) {
                countAll++;
                count1++;
                //同じ、行列に2つ以上ある場合は、誤り
                if (count1 > 1)
                    return (-1);
            }
        }
    }
    //列ごとのチェック
    for (let col = 0; col < BOARD_SIZE; col++) {
        let count1 = 0;
        for (let row = 0; row < BOARD_SIZE; row++) {
            if (workBoard[row][col] === num) {
                count1++;
                //同じ、行列に2つ以上ある場合は、誤り
                if (count1 > 1)
                    return (-1);
            }
        }
    }
    //ブロック(3x3)ごとのチェック
    for (let row = 0; row < BOARD_SIZE; row += 3) {
        for (let col = 0; col < BOARD_SIZE; col += 3) {
            let count1 = 0;
            for (let row1 = 0; row1 < 3; row1++) {
                for (let col1 = 0; col1 < 3; col1++) {
                    if (workBoard[row + row1][col + col1] === num) {
                        count1++;
                        //同じ、ブロックに2つ以上ある場合は、誤り
                        if (count1 > 1)
                            return (-1);
                    }
                }
            }
        }
    }
    return countAll;

}

//
//次の手と次の手選択肢を表示
//
function numpla_showNumbers() {
    //難易度
    const ui_Level = document.getElementById("numpla_Level");
    ui_Level.innerText = g_strLevel;

    //次の手
    const ui_NextMove = document.getElementById("numpla_NextMove");
    let strNextMove = g_nextMove;
    if (strNextMove == 0) {
        strNextMove = "";
    }
    ui_NextMove.innerText = strNextMove;

    //次の手選択肢tableをセット
    const tableNumbers = document.getElementById("numpla_numbers");
    let tr = tableNumbers.rows[0];
    for (let col = 0; col < BOARD_SIZE; col++) {
        let td = tr.cells[col];
        let num = col + 1;
        let count = numpla_countNumber(g_gameBoard, num);
        //クラス名のセット
        let td_className = "numpla_number_normal";
        if (count < 0)
            td_className = "numpla_number_error";
        else if (count == BOARD_SIZE)
            td_className = "numpla_number_complete";
        else if (num == g_nextMove)
            td_className = "numpla_number_selected";
        td.className = td_className;
    }
}

//UNDOボタン
function numpla_onClickButtonUndo() {
    if (g_Undo.length <= 0) {
        return;
    }
    let oldMove = g_Undo.pop();
    g_nextMove = g_Undo.pop();
    let col = g_Undo.pop();
    let row = g_Undo.pop();
    g_gameBoard[row][col] = oldMove;
    //ゲーム盤面表示
    numpla_showBoard();
    numpla_showNumbers();

}

//Restartボタン
function numpla_onClickButtonRestart() {
    if (g_Undo.length <= 0) {
        return;
    }
    if (!confirm("ゲームが初期化されます。よいですか?")) {
        return;
    }
    numpla_RestartGame();
}

//開始ボタン
function numpla_onClickButtonStart(e) {
    //ゲーム中の場合は、確認
    if (g_Undo.length > 0) {
        if (!confirm("ゲームが初期化されます。よいですか?")) {
            return;
        }
    }
    numpla_StartGame(this.level, e.currentTarget.innerText);
}

//
//ボタンの初期化
//
function numpla_initButtons() {
    document.getElementById("numpla_buttonUndo").addEventListener("click", numpla_onClickButtonUndo);
    document.getElementById("numpla_buttonRestart").addEventListener("click", numpla_onClickButtonRestart);
    document.getElementById("numpla_buttonStart10").addEventListener("click", { level: 20, handleEvent: numpla_onClickButtonStart });
    document.getElementById("numpla_buttonStart20").addEventListener("click", { level: 30, handleEvent: numpla_onClickButtonStart });
    document.getElementById("numpla_buttonStart30").addEventListener("click", { level: 40, handleEvent: numpla_onClickButtonStart });
    document.getElementById("numpla_buttonStart40").addEventListener("click", { level: 50, handleEvent: numpla_onClickButtonStart });
    document.getElementById("numpla_buttonStart50").addEventListener("click", { level: 60, handleEvent: numpla_onClickButtonStart });
}

//
//初期処理
//
function numpla_init() {
    //// Display
    //console.log("=== Solution ===");
    //completeBoard.forEach(row => {
    //    console.log(row.join(" "));
    //});

    //console.log("\n=== gameBoard ===");
    //gameBoard.forEach(row => {
    //    console.log(row.map(n => (n !== 0 ? n : ".")).join(" "));
    //});

    //ゲーム盤面を初期化
    numpla_initBoard();

    //次の手選択肢のマスを設定
    numpla_initNumbers();

    //ボタンの初期化
    numpla_initButtons();
}

//ゲーム開始
function numpla_StartGame(level, strLevel) {
    //ゲーム盤面を作成
    const completeBoard = numpla_generateCompleteBoard();
    g_gameBoard = numpla_removeNumbers(completeBoard, level);
    g_backupBoard = numpla_dupBoard(g_gameBoard);
    g_strLevel = strLevel.trim();  //難易度
    //ゲーム開始
    numpla_startGameSub();
}

//ゲーム再開始
function numpla_RestartGame() {
    g_gameBoard = numpla_dupBoard(g_backupBoard);
    //ゲーム開始
    numpla_startGameSub();
}

//ゲーム開始(サブ)
function numpla_startGameSub() {
    g_nextMove = 0;  // 次の手
    numpla_ClearUndo(); //Undoリストをクリアする

    //ゲーム盤面を表示
    numpla_showBoard();

    //次の手のマスを表示
    numpla_showNumbers();

}

//初期処理
window.addEventListener("load", numpla_init);
