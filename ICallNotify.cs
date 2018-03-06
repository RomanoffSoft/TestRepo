using System;
using System.Drawing;

namespace Technology.VoIP
{
    public interface ICallNotify : IDisposable
    {
        int Index { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string Patronymic { get; set; }
        Bitmap Photo { get; set; } // Фото клиента
        string Phone { get; set; } //Номер телефона
        bool KnownPerson { get; set; }
        CallsEventArgs CallInfo { get; set; }
        CallPersonType PersonType { get; set; }

        ContractInfo ContractInfo { get; set; }

        event EventHandler<EventArgs> ButtonClicked; //нажали кнопку на форме (в теге кнопки - инфа, какую нажали)
        CallDirection Direction { get; set; } // Входящий или исходящий звонок

        void Show(); //развернуть уведомление
        void Hide(); //свернуть
        void Init(); // инициализация (если нужна)
        void Close(); //Закрыть и удалить уведомление

        void AlertStart(); // Подсветка уведомления
        void AlertStop();  // Подсветка уведомления (прекратить)

        // Объединены в один эвент ButtonClicked
        //event EventHandler<CallsEventArgs> ShowDetailsClicked; //нажали кнопку "показать информацию о клиенте"
        //event EventHandler<CallsEventArgs> TransferCallClicked; //нажали "перевод звонка"
        //event EventHandler<CallsEventArgs> CreateContactClicked; //нажали "создать новый контакт"
        //event EventHandler<CallsEventArgs> AddToExistingClicked; // нажали "добавить номер к существующему"
    }
    public class ContractInfo
    {
        public string TemplateName { set; get; }
        public DateTime? StopDate { get; set; }
        public string Status { get; set; }
    }
}
