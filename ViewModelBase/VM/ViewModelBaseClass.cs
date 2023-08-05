using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelBase.VM
{
    public class ViewModelBaseClass : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        #region Validation System
        private bool[] m_ValidationArray;
        #endregion

        #endregion

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        #region validation System

        public bool[] ValidationArray
        {
            get => m_ValidationArray;

            protected set => m_ValidationArray = value;
        }

        public virtual string this[string columnName] => throw new NotImplementedException();

        public virtual string Error => throw new NotImplementedException();

        #endregion

        #endregion

        #region Methods
        /// <summary>
        /// OnPropertyChanged Event caller
        /// </summary>
        /// <param name="prop">Name of the Property</param>
        public void OnPropertyChanged(string prop)
        {
            var temp = Volatile.Read(ref PropertyChanged);

            temp?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Changes field with the propety value if field value is not equal to property,
        /// calls OnPropertyChangedEvent
        /// </summary>
        /// <typeparam name="T">Type of the field and property</typeparam>
        /// <param name="field">Field of the ViewModel</param>
        /// <param name="property">Property of the ViewModel</param>
        /// <param name="prop">Unnecessary parametr, will be calculated during runTime.</param>
        /// <returns>Boolean, whether to change field or not</returns>
        /// <exception cref="ArgumentNullException">Will be thrown if field is null</exception>
        public virtual bool SetField<T>(ref T field, 
            T property, [CallerMemberName] string prop = "")
        {
            if (field == null)
                throw new ArgumentNullException("Parametr field wasn't initialized!");

            if (field.Equals(property))
                return false;

            field = property;
            OnPropertyChanged(prop);
            return true;
        }

        /// <summary>
        /// Check wether all values in array is true
        /// </summary>
        /// <returns>Boolean, if all values in array are true</returns>
        protected virtual bool CheckValidArray()
        {
            foreach (bool item in m_ValidationArray)
            
                if (item == false)
                    
                    return false;                           

            return true;
        }

        #endregion

    }
}
