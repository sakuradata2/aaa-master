using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using menu.Messages;
using System.Windows.Controls;
using candy;

namespace menu.ViewModel
{

    public class UserControl1ViewModel : ViewModelBase
    {
        public RelayCommand<UserControl> UCCommand { get; set; }
        private UserControl candyUC;

        public UserControl CandyUC
        {
            get 
            {
                if (candyUC == null)
                {
                    candyUC = new candy.UserControl1() as UserControl;

                    ExecuteUCCommand(candyUC);
                }
                return candyUC; 
            }
            set { candyUC = value; }
        }

        private UserControl computerUC;

        public UserControl ComputerUC
        {
            get
            {
                if (computerUC == null)
                {
                    computerUC = new computer.UserControl1() as UserControl;
                    //ExecuteUCCommand(computerUC);

                }
                return computerUC;
            }
            set { computerUC = value; }
        }

        public UserControl1ViewModel()
        {
            UCCommand = new RelayCommand<UserControl>(ExecuteUCCommand);

        }
        private void ExecuteUCCommand(UserControl uc)
        {

            var msg = new SwopUserControl { uc=uc };
            Messenger.Default.Send<SwopUserControl>(msg);
        }
    }
}