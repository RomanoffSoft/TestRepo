using System;
using System.Collections.Generic;
using System.Text;

namespace Technology.VoIP
{
    /// <summary>
    /// Информация о звонке
    /// </summary>
    [Serializable()]
    public class CallsEventArgs : EventArgs
    {
        /// <summary>
        /// Телефон вызывающего абонента (исходящий)
        /// </summary>
        public string srcPhone { set; get; }
        /// <summary>
        /// Телефон вызываемого абонента (входящий)
        /// </summary>
        public string dstPhone { set; get; }
        /// <summary>
        /// Внутренний ID звонка, назначенный VoIP - сервером
        /// </summary>
        public string CallID { set; get; }
        /// <summary>
        /// Тип вызова (входящий исходящий)
        /// </summary>
        public CallDirection CallDirection { set; get; }
        /// <summary>
        /// Тип звонка (начальный звонок, ответ, звонок завершен)
        /// </summary>

        public CallType CallType { set; get; }

        /// <summary>
        /// Вызов был отменен
        /// </summary>
        public bool Cancelled { set; get; }
        /// <summary>
        /// Дата и время начала вызова
        /// </summary>
        public DateTime Start { set; get; }
        /// <summary>
        /// Дата и время окончания вызова
        /// </summary>
        public DateTime Stop { set; get; }
        /// <summary>
        /// Длительность вызова
        /// </summary>
        public TimeSpan Duration { set; get; }
        /// <summary>
        /// Клиент или контакт (если звонят с известного номера)
        /// </summary>
        //     public IEntityContainer Person { set; get; }
        /// <summary>
        /// URL записи разговора
        /// </summary>
        public string RecordURL { set; get; }
    }
    public enum CallDirection { Incoming, Outgoing }
    public enum CallPersonType { Unknown, PotentialClient, ActualClient } // тип позвонившей персоны (неизвестен, контакт или клиент)
    public enum CallType { Call, Answer, Completed }
}
