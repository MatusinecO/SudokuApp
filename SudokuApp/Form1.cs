using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuApp
{
    public partial class Form1 : Form
    {
        //Initialization of Solver class, textboxes and buttons
        private SudokuSolver solver;
        private TextBox[,] textBoxes;

        //Form constructor
        public Form1()
        {
            InitializeComponent();
            InitializeSudokuBoard();
            InitializeDefaultSudokuBoard();

        }

        //Empty form loading
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Sudoku board initialization (creating text boxes for for numbers)
        private void InitializeSudokuBoard()
        {
            textBoxes = new TextBox[9, 9]; //Initialize field of textboxes
            //
            const int textBoxSize = 40;
            const int startX = 20;
            const int startY = 20;
            const int subTableSize = textBoxSize * 3 + 2; // subtable size to 3x3

            for (int subTableRow = 0; subTableRow < 3; subTableRow++)
            {
                for (int subTableCol = 0; subTableCol < 3; subTableCol++)
                {
                    // Creating subtable 3x3
                    Panel subTablePanel = new Panel
                    {
                        Width = subTableSize,
                        Height = subTableSize,
                        Location = new Point(startX + subTableCol * (subTableSize + 2), startY + subTableRow * (subTableSize + 2)),
                        BorderStyle = BorderStyle.FixedSingle // Subtable border
                    };

                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            //Creating textbox in subtable
                            int absoluteRow = subTableRow * 3 + row;
                            int absoluteCol = subTableCol * 3 + col;

                            textBoxes[absoluteRow, absoluteCol] = new TextBox
                            {
                                Width = textBoxSize,
                                Height = textBoxSize,
                                Location = new Point(col * (textBoxSize + 2), row * (textBoxSize + 2)),
                                TextAlign = HorizontalAlignment.Center,
                                Font = new Font(Font.FontFamily, 14),
                                Tag = new Tuple<int, int>(absoluteRow, absoluteCol)
                            };
                            textBoxes[absoluteRow, absoluteCol].KeyPress += TextBox_KeyPress;
                            subTablePanel.Controls.Add(textBoxes[absoluteRow, absoluteCol]);
                        }
                    }

                    Controls.Add(subTablePanel);
                }
            }
        }

        // Set default numbers into the board. (Add random class to generate new numbers for every game?)
        private void InitializeDefaultSudokuBoard()
        {
            int[,] defaultBoard = new int[9, 9] {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 6, 0},
        {8, 0, 0, 0, 6, 0, 0, 0, 3},
        {4, 0, 0, 8, 0, 3, 0, 0, 1},
        {7, 0, 0, 0, 2, 0, 0, 0, 6},
        {0, 6, 0, 0, 0, 0, 2, 8, 0},
        {0, 0, 0, 4, 1, 9, 0, 0, 5},
        {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
            // Set default numbers to textboxes
            SetBoardToTextBoxes(defaultBoard);

            // Disable textboxes for positions with default values
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (defaultBoard[row, col] != 0)
                    {
                        textBoxes[row, col].Enabled = false;
                    }
                }
            }
        }

        // Event handler for the key press in textboxes
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits in the textboxes
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Allow only one digit from 1 to 9
            TextBox textBox = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                int number = int.Parse(e.KeyChar.ToString());
                if (number < 1 || number > 9)
                {
                    e.Handled = true;
                }
                else
                {
                    textBox.Text = e.KeyChar.ToString();
                    e.Handled = true;
                }
            }
        }

        //Get the sudoku board from textboxes
        private int[,] GetBoardFromTextBoxes()
        {
            //2D array to hold the sudoku board
            int[,] board = new int[9, 9];

            //Loop all the textboxes and parse their content to integers
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!int.TryParse(textBoxes[row, col].Text, out board[row, col]))
                    {
                        //If parsing fails, set value to 0
                        board[row, col] = 0;
                    }
                }
            }

            return board;
        }

        // Set the sudoku board to textboxes
        private void SetBoardToTextBoxes(int[,] board)
        {
            // Loop through all the textboxes and set their text based on the board values
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    textBoxes[row, col].Text = board[row, col] == 0 ? "" : board[row, col].ToString();
                }
            }
        }

        // Event handler for clicking the Solve button
        private void SolveButton_Click(object sender, EventArgs e)
        {
            //Get the sudoku board from textboxes
            int[,] board = GetBoardFromTextBoxes();
            //Create sudoku solver instance with the current board
            solver = new SudokuSolver(board);

            //Solve the sudoku puzzle
            if (solver.Solve())
            {
                //If solution exists, set solution to textboxes
                SetBoardToTextBoxes(solver.GetSolution());
            }
            else
            {
                //No solution - show messageBox
                MessageBox.Show("No solution exists.");
            }
        }

        //Event handler for clicking Retry button
        private void RetryButton_Click(object sender, EventArgs e)
        {
            //Reset sudoku to default values
            InitializeDefaultSudokuBoard();
        }

        // Event handler for clicking the Save button
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Get name of the game from player
            string gameName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the game:", "Game Name", "SudokuGame");

            //Save the game to the database
            using (var context = new SudokuContext())
            {
                var board = GetBoardFromTextBoxes();
                var game = new SudokuGame
                {
                    Name = gameName, // Use the entered game name
                    //Serialize the board state to string
                    BoardState = SerializeBoard(board)
                };
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        // Event handler for clicking the Load button
        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Create the comboBox for selecting the game to load
            ComboBox gameComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "Name"
            };

            // Load the list of games from database
            using (var context = new SudokuContext())
            {
                var games = context.Games.ToList();
                foreach (var game in games)
                {
                    gameComboBox.Items.Add(game);
                }
            }

            // Creating a custom dialog form
            Form dialogForm = new Form
            {
                Text = "Load Game",
                Size = new System.Drawing.Size(300, 150),
                StartPosition = FormStartPosition.CenterParent
            };

            // Add comboBox to the dialog form 
            gameComboBox.Location = new System.Drawing.Point(50, 30);
            dialogForm.Controls.Add(gameComboBox);

            // Add OK button to the dialog form
            Button okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(50, 70)
            };
            dialogForm.Controls.Add(okButton);

            // Add Cancel button to the dialog form
            Button cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(150, 70)
            };
            dialogForm.Controls.Add(cancelButton);

            // Display the dialog form and process the selection
            DialogResult result = dialogForm.ShowDialog();

            if (result == DialogResult.OK && gameComboBox.SelectedItem != null)
            {
                // if OK clicked + game selected -> load selected game 
                var selectedGame = (SudokuGame)gameComboBox.SelectedItem;
                var board = DeserializeBoard(selectedGame.BoardState);
                SetBoardToTextBoxes(board);
            }
            else
            {
                //Message box if no game is selected, or operation was cancelled
                MessageBox.Show("No game selected or operation cancelled.");
            }
        }

        // Serialization board state to string
        private string SerializeBoard(int[,] board)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    sb.Append(board[row, col]);
                }
            }
            return sb.ToString();
        }

        // Deserialize string to a board state
        private int[,] DeserializeBoard(string boardString)
        {
            int[,] board = new int[9, 9];
            int index = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    board[row, col] = int.Parse(boardString[index].ToString());
                    index++;
                }
            }
            return board;
        }


    }
}
