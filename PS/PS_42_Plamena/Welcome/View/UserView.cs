using System.Text;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public void Display()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Welcome");
            sb.AppendLine("User:" +  _viewModel.Name);
            sb.AppendLine("Role:" + _viewModel.Role);

            Console.WriteLine(sb.ToString());
        }

        public void DisplayError()
        {
            throw new Exception("ERROR!");
        }
    }
}
