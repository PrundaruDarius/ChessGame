using System.Windows;
using System.Windows.Controls;
using ChessLogic;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }
        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White Wins",
                Player.Black => "Black Wins",
                _ => "Draw"
            };
        }
        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }
        private static string GetReasonText(EndReason reason ,Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"Stalmate -{PlayerString(currentPlayer)} can't move",
                EndReason.Checkmate => $"Checkmate",
                EndReason.FiftyMoveRule => $"Draw-Fifty-move rule",
                EndReason.InsuficientMaterial => "Insuficient material",
                EndReason.ThreefoldRepetition => "Threefold repetition",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }

    }
}
