using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserAccountCreator.ViewModels.Modals;

namespace UserAccountCreator.Views.Modals
{
    /// <summary>
    /// Логика взаимодействия для UserCreationModal.xaml
    /// </summary>
    public partial class UserCreationModal : UserControl
    {
        public UserCreationModal()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext is UserCreationModalViewModel dataContext) 
            {
                dataContext.FullNameChanged((sender as TextBox).Text);
            }
        }
    }
}
