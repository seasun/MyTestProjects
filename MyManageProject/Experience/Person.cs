using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Experience
{
    class Person : INotifyPropertyChanged
    {
        private string _name = string.Empty;

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// 屬性更改的處理方法
        /// </summary>
        /// <param name="propertyName">屬性名稱</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    }
}
