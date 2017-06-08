using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfApplication1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string avtor1 { get; set; }
        public string avtor2 { get; set; }
        public string novavtor { get; set; }
        public string namebook { get; set; }
        public string nameizdatel { get; set; }
        public int _nameyear { get; set; }
        public int _tiraj { get; set; }
        public string isbn { get; set; }
        public ICommand save { get; set; }
        public ICommand otmena { get; set; }

        public int nameyear
        {
            get { return _nameyear; }
            set
            {
                if (value > 0)
                {
                    _nameyear = value;
                    Notify(nameof(nameyear));
                }
                else
                {

                }
            }
        }


        public int tiraj
        {
            get { return _tiraj; }
            set
            {
                if (value > 0)
                {
                    _tiraj = value;
                    Notify(nameof(tiraj));
                }
                else
                {

                }
            }
        }

        private void Notify(string v)
        {
            //  throw new NotImplementedException(v);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static void PushLine(int isbn, string namebook, string avtor, int nameyear, int tiraj, int IDizd)
        {
            using (SqlConnection cn = new SqlConnection ("Server = COMP\\SQLEXPRESS ; Database = myDataBase; Trusted_Connection = True;"))
            {
                cn.Open();
                string sql = string.Format("INSERT INTO Books(isbn, namebook, avtor, nameyear, tiraj, IDizd, ) values('{0}','{1}','{2}','{3}','{4}','{5}')", isbn, namebook, avtor, nameyear, tiraj, IDizd);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
