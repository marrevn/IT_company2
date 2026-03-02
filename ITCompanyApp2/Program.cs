namespace ITCompanyApp2
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formTasks = new FormTasks(formLogin.CurrentUser, formLogin.IsGuest))
                        {
                            if (formTasks.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}
