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
using System.Windows.Shapes;
using Presentation.ViewModel;
using Presentation.Model;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private TaskViewModel vm;
        
        public TaskWindow(BackendController controller, MTask t)
        {
            InitializeComponent();
            vm = new TaskViewModel(controller, t);
            this.DataContext = vm;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EditButton_Click();
        }
    }
}
