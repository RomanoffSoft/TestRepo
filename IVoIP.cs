using System;
using System.Collections.Generic;
using System.Text;

namespace Technology.VoIP
{
    public interface IVoIP : IDisposable
    {
        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        string PhoneNumber { get; }


        /// <summary>
        /// Статус соединения (открыто или закрыто)
        /// </summary>
        bool State { get; }


        ///// <summary>
        ///// Инициализация библиотеки от поставщиков IP-телефонии, необходимой для интеграции с Профилем
        ///// </summary>
        //void Initialize();
        /// <summary>
        /// Соединение с сервером VoIP
        /// </summary>
        void Connect();
        /// <summary>
        /// Исходящий звонок
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        void MakeCall(string phone);
        /// <summary>
        /// Переадресовать вызов
        /// </summary>
        /// <param name="phone"></param>
        void TransferCall(string CallID, string phone);
        /// <summary>
        /// Отсоединения от VoIP-сервера
        /// </summary>
        void Disconnect();
        /// <summary>
        /// Событие - поступил входящий звонок от клиента
        /// </summary>
        event EventHandler<CallsEventArgs> TransferredCall;
        /// <summary>
        /// Событие - переадресация звонка
        /// </summary>
        event EventHandler<CallsEventArgs> TransferRequest;
        /// <summary>
        /// Событие - звонок завершен (для истории звонков и сохранения события в Профиле)
        /// </summary>
        event EventHandler<CallsEventArgs> CompletedCall;
        /// <summary>
        /// Событие - ответ на входящий звонок
        /// </summary>
        event EventHandler<CallsEventArgs> TransferredCallAnswer;
        /// <summary>
        /// Событие - исходящий звонок
        /// </summary>
        event EventHandler<CallsEventArgs> OutgoingCall;
        /// <summary>
        /// Событие - ответ на исходящий звонок
        /// </summary>
        event EventHandler<CallsEventArgs> OutgoingCallAnswer;

    }
}
