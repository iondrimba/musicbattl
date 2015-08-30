namespace MusicBattlBLL.models
{
    public class PassWordChange
    {
        private int _IdUsuario = 0;

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        private string _currentPassword = string.Empty;

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set { _currentPassword = value; }
        }

        private string _newPassword = string.Empty;

        public string NewPassword
        {
            get { return _newPassword; }
            set { _newPassword = value; }
        }

        private string _confirmPassword = string.Empty;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }
    }
}