using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlaintextEncoder.ViewModel {
    internal class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(field, newValue)) {
                return false;
            }
            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool Update([CallerMemberName] string? propertyName = null) {
            OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
