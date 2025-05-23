using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace numpla
{
    public partial class NumplaForm : Form
    {

        //グローバル変数
        const int BOARD_SIZE = 9;
        Color color_empty = Color.White;            //空
        Color color_complete = Color.Khaki;         //完成
        Color color_next = Color.Aqua;              //次の手
        Color color_error = Color.Tomato;           //エラー
        Color color_base = Color.LightBlue;         //基本
        Color color_move = Color.LightCyan;         //置いた手

        private int[,] g_gameBoard = new int[BOARD_SIZE, BOARD_SIZE];       // ゲーム盤面
        private int[,] g_baseBoard = new int[BOARD_SIZE, BOARD_SIZE];       // 初期盤面
        private string g_strLevel = "";    // 難易度
        private int g_nextMove = 0;        // 次の手
        private Stack<int> g_Undo = new Stack<int>(); // undoリスト

        public NumplaForm()
        {
            InitializeComponent();
        }

        //
        // Undoリストをクリアする(初期化)
        //

        public void Numpla_ClearUndo()
        {
            g_Undo = new Stack<int>(); // undoリスト
        }


        // 次の手(num)が指定されたマス(row, col)に置けるかチェックする
        // return : false -> 置けない, true -> 置ける
        public bool Numpla_isValid(int[,] board, int row, int col, int num)
        {
            //同じ列にnumと同じ数字がある場合は、置けない
            for (int row1 = 0; row1 < BOARD_SIZE; row1++)
            {
                if (row1 != row && board[row1, col] == num)
                {
                    return false;
                }
            }
            //同じ行にnumと同じ数字がある場合は、置けない
            for (int col1 = 0; col1 < BOARD_SIZE; col1++)
            {
                if (col1 != col && board[row, col1] == num)
                {
                    return false;
                }
            }

            // 3×3のブロックにnumと同じ数字がある場合は、置けない
            int startRow = 3 * (row / 3);
            int startCol = 3 * (col / 3);
            for (int row1 = 0; row1 < 3; row1++)
            {
                int row2 = startRow + row1;
                for (int col1 = 0; col1 < 3; col1++)
                {
                    int col2 = startCol + col1;
                    if (row2 != row && col2 != col && board[row2, col2] == num)
                    {
                        return false;
                    }
                }
            }
            //置ける
            return true;
        }

        // ゲーム盤面から空のマスを探す
        // return : 見つかった時[row, col], 見つからなかったとき -1,-1
        public (int row, int col) Numpla_findEmptyCell(int[,] board)
        {
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return (row, col);
                    }
                }
            }
            return (-1, -1);
        }


        // ナンプレを解く (with option to count solutions)
        //return :
        // countSolutionsがfalseの場合
        //  1 : 完了(解けた)  0: 解けない
        // countSolutionsがtrueの場合
        //  1以上 : 解の数(1:正規)  0 : 解けない

        public int Numpla_solve(int[,] board, bool countSolutions = false, int maxSolutions = 2)
        {
            // 空きマスを探す
            var emptyCell = Numpla_findEmptyCell(board);
            // 空きマスが無ければ、完了(OK)
            if (emptyCell.row < 0)
            {
                //return countSolutions ? 1 : true;
                return (1);
            }

            // 空きマスに数値をセットして再帰的にナンプレを解く
            int row = emptyCell.row;
            int col = emptyCell.col;
            int totalSolutions = 0;

            for (int num = 1; num <= BOARD_SIZE; num++)
            {
                // 空きマスに数値をセット
                if (Numpla_isValid(board, row, col, num))
                {
                    board[row, col] = num;
                    // 再帰的にナンプレを解く
                    int result = Numpla_solve(board, countSolutions, maxSolutions);
                    if (countSolutions)
                    {
                        //if (result is int)
                        //{
                        // 解けた場合は、OK
                        totalSolutions += result;
                        if (totalSolutions >= maxSolutions)
                        {
                            break;
                        }
                        //}
                    }
                    else
                    {
                        if (result > 0)
                        {
                            // 解けた場合は、OK
                            return 1;
                        }
                    }
                    // 解けなかった場合は、戻す
                    board[row, col] = 0;
                }
            }

            //return countSolutions ? totalSolutions : false;
            return countSolutions ? totalSolutions : 0;
        }

        //完成版のゲーム盤面を作成する
        private int[,] Numpla_generateCompleteBoard()
        {
            // 空(0要素)のゲーム盤面(9×9)を作る
            int[,] completeBoard = new int[BOARD_SIZE, BOARD_SIZE];
            // 1～9の数値列を作る
            int[] baseNumbers = Enumerable.Range(1, BOARD_SIZE).ToArray();

            //完成版のゲーム盤面に数値を埋める(再帰)
            bool numpla_fillboard()
            {
                //空のマスを探す。空のマスが無ければ完成。
                var emptyCell = Numpla_findEmptyCell(completeBoard);
                if (emptyCell.row < 0)
                {
                    return true;
                }

                int row = emptyCell.row;
                int col = emptyCell.col;
                //1～9の数値列をかき混ぜる
                int[] shuffledNumbers = Enumerable.Range(1, BOARD_SIZE).ToArray();
                //シャッフルする
                var rand = new Random();
                shuffledNumbers = shuffledNumbers.OrderBy(i => rand.Next()).ToArray();
                foreach (int num in shuffledNumbers)
                {
                    //指定されたマスに置けるかチェックする
                    if (Numpla_isValid(completeBoard, row, col, num))
                    {
                        //置ける場合は、次の数字(階層)を試す
                        completeBoard[row, col] = num;
                        if (numpla_fillboard())
                        {
                            return true;
                        }
                        //置けない場合は、戻す。(別の数字を試す)
                        completeBoard[row, col] = 0;
                    }
                }
                return false;
            }

            //ゲーム盤面に数値を埋める
            numpla_fillboard();
            return completeBoard;
        }


        // ゲーム盤面の複製を作る
        private int[,] NumplaDupBoard(int[,] board)
        {
            int[,] result = new int[BOARD_SIZE, BOARD_SIZE];
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    result[row, col] = board[row, col];
                }
            }
            return result;
        }

        //
        //完成ゲーム盤面から、単一の解がある状態を保持したまま、数字を削除して、問題ゲーム盤面を作成する。
        //
        int[,] Numpla_removeNumbers(int[,] board, int tryCount = 50)
        {
            //完成ゲーム盤面から問題ゲーム盤面を作る
            int[,] workBoard = NumplaDupBoard(board);
            //乱数
            var rand = new Random();
            while (tryCount > 0)
            {
                //問題ゲーム盤面の空きにするマスを選ぶ(ランダム)
                int row = (int)(((double)rand.Next() / int.MaxValue) * BOARD_SIZE);
                int col = (int)(((double)rand.Next() / int.MaxValue) * BOARD_SIZE);
                //すでに空きの場合、別のマスへ
                if (workBoard[row, col] == 0)
                {
                    continue;
                }

                //マスを空きにしてみて、解が1つだけ見つかるか試行する。
                //見つかったら、次の手へ。見つからなかったら、戻す。
                {
                    int backupNumber = workBoard[row, col];
                    workBoard[row, col] = 0;
                    //試行用のゲーム盤面を作る
                    int[,] boardCheck = NumplaDupBoard(workBoard);
                    int solutions = Numpla_solve(boardCheck, true, 2);
                    if (solutions != 1)
                    {
                        workBoard[row, col] = backupNumber; // 見つからなかったら、戻す。
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
        private void Numpla_initBoard()
        {
            //tableにセット
            numpla_board.Rows.Clear();
            numpla_board.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            numpla_board.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                numpla_board.Rows.Add();
                DataGridViewRow tr = numpla_board.Rows[row];
                tr.Height = 40;
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    DataGridViewCell td = tr.Cells[col];
                }
            }
        }

        //
        //ゲーム盤面を表示
        //
        private void Numpla_showBoard()
        {
            //tableにセット
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                DataGridViewRow tr = numpla_board.Rows[row];
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    //マスごとにスタイルと内容をセット
                    DataGridViewCell td = tr.Cells[col];
                    int num = g_gameBoard[row, col];
                    string strNum = num.ToString();
                    Color cr = color_empty;//空のマス

                    if (num == 0)
                    {
                        strNum = "・";
                    }
                    else
                    {
                        cr = color_move;    //置いた手
                        if (g_baseBoard[row, col] != 0)
                        {
                            cr = color_base;
                        }
                        if (num == g_nextMove)
                        {
                            cr = color_next;
                        }
                        bool result = Numpla_isValid(g_gameBoard, row, col, num);
                        if (!result)
                        {
                            cr = color_error;    //誤りのマス
                        }
                    }
                    td.Value = strNum;

                    td.Style.BackColor = cr;
                    td.Style.SelectionBackColor = cr;
                    td.Style.ForeColor = Color.Black;
                    td.Style.SelectionForeColor = Color.Black;
                }
            }

        }

        //盤面クリック時の処理
        private void Numpla_board_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //マスを特定
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (g_nextMove != 0 && g_baseBoard[row, col] == 0)
            {
                //初期盤面で空きのマスのみ次の手をセットまたはクリアできる。
                int oldMove = g_gameBoard[row, col];
                int newMove = g_nextMove;
                if (oldMove == g_nextMove)
                {
                    //２回目はマスをクリア
                    newMove = 0;
                }
                //マスに設定
                g_gameBoard[row, col] = newMove;
                //undo用
                g_Undo.Push(row);
                g_Undo.Push(col);
                g_Undo.Push(g_nextMove);
                g_Undo.Push(oldMove);
                //ゲーム盤面を表示
                Numpla_showBoard();
                //次の手選択肢のマスを表示
                Numpla_showNumbers();
                //終了チェック
                if (Numpla_checkFinished())
                {
                    Numpla_ClearUndo(); //Undoリストをクリアする
                    MessageBox.Show("成功です!!", "ナンプレ");
                }
            }
        }

        //終了チェック
        private bool Numpla_checkFinished()
        {
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                int num = col + 1;
                int count = Numpla_countNumber(g_gameBoard, num);
                if (count != BOARD_SIZE)
                {
                    return (false);
                }
            }
            return (true);
        }

        //
        //次の手選択肢のマスをクリックしたときの処理
        //(次の手をセットする)
        //
        private void Numpla_numbers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //次の手
            //console.log(this);
            g_nextMove = e.ColumnIndex + 1;

            //ゲーム盤面表示
            Numpla_showBoard();
            //次の手選択肢のマスを表示
            Numpla_showNumbers();
        }

        //
        //次の手選択肢のマスを設定
        //
        void Numpla_initNumbers()
        {
            //tableにセット
            numpla_numbers.Rows.Add(1);
            numpla_numbers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewRow tr = numpla_numbers.Rows[0];
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                DataGridViewCell td = tr.Cells[col];
                td.Value = col + 1;
            }

        }

        //
        //ゲーム盤面の数字の数を数える
        //return : 誤りの場合は -1、OKの場合は、0以上
        //
        private int Numpla_countNumber(int[,] workBoard, int num)
        {
            int countAll = 0;
            //行ごとのチェック
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                int count1 = 0;
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    if (workBoard[row, col] == num)
                    {
                        countAll++;
                        count1++;
                        //同じ、行列に2つ以上ある場合は、誤り
                        if (count1 > 1)
                            return (-1);
                    }
                }
            }
            //列ごとのチェック
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                int count1 = 0;
                for (int row = 0; row < BOARD_SIZE; row++)
                {
                    if (workBoard[row, col] == num)
                    {
                        count1++;
                        //同じ、行列に2つ以上ある場合は、誤り
                        if (count1 > 1)
                            return (-1);
                    }
                }
            }
            //ブロック(3x3)ごとのチェック
            for (int row = 0; row < BOARD_SIZE; row += 3)
            {
                for (int col = 0; col < BOARD_SIZE; col += 3)
                {
                    int count1 = 0;
                    for (int row1 = 0; row1 < 3; row1++)
                    {
                        for (int col1 = 0; col1 < 3; col1++)
                        {
                            if (workBoard[row + row1, col + col1] == num)
                            {
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
        private void Numpla_showNumbers()
        {
            //難易度
            numpla_Level.Text = g_strLevel;

            //次の手
            string strNextMove = g_nextMove.ToString();
            if (g_nextMove == 0)
            {
                strNextMove = "";
            }
            numpla_NextMove.Text = strNextMove;

            //次の手選択肢tableをセット
            DataGridViewRow tr = numpla_numbers.Rows[0];
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                var td = tr.Cells[col];
                int num = col + 1;
                int count = Numpla_countNumber(g_gameBoard, num);
                //色のセット
                Color cr = color_empty;
                if (count < 0)
                    cr = color_error;
                else if (count == BOARD_SIZE)
                    cr = color_complete;
                else if (num == g_nextMove)
                    cr = color_next;
                td.Style.BackColor = cr;
                td.Style.ForeColor = Color.Black;
                td.Style.SelectionBackColor = cr;
                td.Style.SelectionForeColor = Color.Black;
            }
        }




        //UNDOボタン
        private void Numpla_buttonUndo_Click(object sender, EventArgs e)
        {
            if (g_Undo.Count <= 0)
            {
                return;
            }
            int oldMove = g_Undo.Pop();
            g_nextMove = g_Undo.Pop();
            int col = g_Undo.Pop();
            int row = g_Undo.Pop();
            g_gameBoard[row, col] = oldMove;
            //ゲーム盤面表示
            Numpla_showBoard();
            Numpla_showNumbers();

        }

        //Restartボタン
        private void Numpla_buttonRestart_Click(object sender, EventArgs e)
        {
            if (g_Undo.Count <= 0)
            {
                return;
            }
            if (MessageBox.Show("ゲームが初期化されます。よいですか?", "ナンプレ", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Numpla_RestartGame();
        }

        //開始ボタン
        private void Numpla_buttonStart10_Click(object sender, EventArgs e)
        {
            Numpla_buttonStart_Click(10, sender, e);
        }

        private void Numpla_buttonStart20_Click(object sender, EventArgs e)
        {
            Numpla_buttonStart_Click(20, sender, e);
        }

        private void Numpla_buttonStart30_Click(object sender, EventArgs e)
        {
            Numpla_buttonStart_Click(30, sender, e);
        }

        private void Numpla_buttonStart40_Click(object sender, EventArgs e)
        {
            Numpla_buttonStart_Click(40, sender, e);
        }

        private void Numpla_buttonStart50_Click(object sender, EventArgs e)
        {
            Numpla_buttonStart_Click(50, sender, e);
        }
        private void Numpla_buttonStart_Click(int level, object sender, EventArgs e)
        {
            //ゲーム中の場合は、確認
            if (g_Undo.Count > 0)
            {
                if (MessageBox.Show("ゲームが初期化されます。よいですか?", "ナンプレ", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            Numpla_StartGame(level, ((Control)sender).Text);
        }

        //
        //ボタンの初期化
        //
        private void Numpla_initButtons()
        {
        }

        //
        //初期処理
        //
        private void Numpla_init()
        {
            //ゲーム盤面を初期化
            Numpla_initBoard();

            //次の手選択肢のマスを設定
            Numpla_initNumbers();

            //ボタンの初期化
            Numpla_initButtons();
        }

        //ゲーム開始
        private void Numpla_StartGame(int level, string strLevel)
        {
            //ゲーム盤面を作成
            int[,] completeBoard = Numpla_generateCompleteBoard();
            g_gameBoard = Numpla_removeNumbers(completeBoard, level);
            g_baseBoard = NumplaDupBoard(g_gameBoard);
            g_strLevel = strLevel.Trim();  //難易度

            //ゲーム開始
            Numpla_startGameSub();
        }

        //ゲーム再開始
        private void Numpla_RestartGame()
        {
            g_gameBoard = NumplaDupBoard(g_baseBoard);
            //ゲーム開始
            Numpla_startGameSub();
        }

        //ゲーム開始(サブ)
        private void Numpla_startGameSub()
        {
            g_nextMove = 0;  // 次の手
            Numpla_ClearUndo(); //Undoリストをクリアする

            //ゲーム盤面を表示
            Numpla_showBoard();

            //次の手のマスを表示
            Numpla_showNumbers();

        }

        private void Numpla_Form_Load(object sender, EventArgs e)
        {
            Numpla_init();
        }

        private void numpla_board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int row = e.RowIndex % 3;
            switch (row)
            {
                case 0:
                    {
                        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Inset;
                    }
                    break;
                case 2:
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
                    }
                    break;

            }
            int col = e.ColumnIndex % 3;
            switch (col)
            {
                case 0:
                    {
                        e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Inset;
                    }
                    break;
                case 2:
                    {
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Inset;
                    }
                    break;

            }

        }
    }
}
