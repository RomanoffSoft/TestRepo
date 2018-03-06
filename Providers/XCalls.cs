using CTIControlLib;
using log4net;
using System;
using System.Runtime.InteropServices;

namespace Technology.VoIP
{
    /// <summary>
    /// Класс для интеграции с решением "Y" компании X
    /// </summary>
    public class XCalls : IVoIP
    {
        private CTIControlX cti;
        private string server;
        private string password;
        private string managerphone;
        private string guid;
        private string logfile;
        private int timeout;
        private static readonly ILog log = LogFactory.GetLogger(typeof(XCalls));
        public event EventHandler<CallsEventArgs> TransferredCall;
        public event EventHandler<CallsEventArgs> TransferRequest;
        public event EventHandler<CallsEventArgs> CompletedCall;
        public event EventHandler<CallsEventArgs> TransferredCallAnswer;
        public event EventHandler<CallsEventArgs> OutgoingCallAnswer;
        public event EventHandler<CallsEventArgs> OutgoingCall;


        private string _prefix;

        public XCalls(string Server, string Password, string ManagerPhone)
        {
            try
            {
                server = Server;
                password = Password;
                managerphone = ManagerPhone;
                guid = Guid.NewGuid().ToString();
                logfile = AppDomain.CurrentDomain.BaseDirectory + "Calls.txt";
                cti = new CTIControlX();
                cti.phoneNumber = managerphone;
                //     manager = new NotifyManager();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public XCalls(string Server, string Password, string ManagerPhone, string GUID, string LogFile)
            : this(Server, Password, ManagerPhone)
        {
            server = Server;
            password = Password;
            managerphone = ManagerPhone;
            guid = GUID;
            logfile = LogFile;
        }

        public XCalls(string Server, string Password, string ManagerPhone, string GUID, string LogFile, bool BroadCast)
            : this(Server, Password, ManagerPhone, GUID, LogFile)
        {
            if (BroadCast)
            {
                cti.broadcastEventsMask = 127;
            }
        }

        //    private bool _state;
        public bool State
        {
            get
            {
                if (cti != null && cti.connectionState == 1)
                    return true;
                else
                    return false;
            }
        }

        public void Connect()
        {
            try
            {
                log.Debug("Trying to connect");
                if (State)
                {
                    cti.Disconnect();
                }
              
                int ret = cti.Connect(server, password, "Access", guid, logfile,0, 2000);
                log.Debug("Connection Establishing");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cti.OnTransferredCall += cti_OnTransferredCall;
                cti.OnTransferRequest += cti_OnTransferRequest;
                cti.OnCompletedCall += cti_OnCompletedCall;
                cti.OnTransferredCallAnswer += cti_OnTransferredCallAnswer;
                cti.OnOutcomingCallAnswer += cti_OnOutcomingCallAnswer;
                cti.OnOutcomingCall += cti_OnOutcomingCall;
            }

        }

        void cti_OnOutcomingCall(string CallID, string src, string dst)
        {
            log.Debug("Outgoing call detected from " + src + " to " + dst);
            EventHandler<CallsEventArgs> handler = OutgoingCall;
            if (handler != null)
            {
                OutgoingCall(this, new CallsEventArgs { CallID = CallID, srcPhone = src, dstPhone = dst, CallDirection = CallDirection.Outgoing });
            }
        }

        void cti_OnOutcomingCallAnswer(string CallID, string src, string dst)
        {
            log.Debug("Outgoing call answer detected from " + src + " to " + dst);
            if (OutgoingCallAnswer != null)
            {
                OutgoingCallAnswer(this, new CallsEventArgs { CallID = CallID, srcPhone = src, dstPhone = dst });
            }
        }

        void cti_OnTransferredCallAnswer(string CallID, string src, string dst)
        {
            log.Debug("Incomig call answered from " + src + " to " + dst);
            if (TransferredCallAnswer != null)
            {
                TransferredCallAnswer(this, new CallsEventArgs { dstPhone = dst, srcPhone = src, CallID = CallID });
            }
        }

        void cti_OnCompletedCall(string CallID, string src, string dst, int duration, string start, string end, int direction, string record)
        {
            log.Debug("CallCompleted detected from " + src + " to " + dst + "Direction:" + direction);
            TimeSpan span = TimeSpan.FromSeconds(duration);

            TimeSpan spanst = TimeSpan.FromSeconds(Convert.ToInt64(start));
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);                //как оказалось,в этом решении шифруются даты как кол-во секунд, прошедших с 1 янв. 1970 года
            DateTime startdate = origin.AddSeconds(Convert.ToInt64(start));
            DateTime stopdate = origin.AddSeconds(Convert.ToInt64(end));
            CallDirection calldirection = direction == 0 ? CallDirection.Incoming : CallDirection.Outgoing;
            //   Convert.ToDateTime(spanst.Seconds);
            if (CompletedCall != null)
            {
                CompletedCall(this, new CallsEventArgs { CallID = CallID, dstPhone = dst, srcPhone = src, Duration = span, Start = startdate, Stop = stopdate,CallDirection=calldirection });
            }
        }

        void cti_OnTransferRequest(string CallID, string from)
        {
            log.Debug("Transfer request from " + from);
            OnTransferredCall(new CallsEventArgs { dstPhone = managerphone, srcPhone = from, CallID = CallID });
        }

        void cti_OnTransferredCall(string CallID, string src, string dst)
        {
            log.Debug("Incoming call detected from " + src + " to " + dst);
            OnTransferredCall(new CallsEventArgs { dstPhone = dst, srcPhone = src, CallID = CallID, CallDirection = CallDirection.Incoming });
        }

        public void MakeCall(string phone)
        {
            log.Debug("trying to make call to " + phone);
            try
            {
                cti.Call(managerphone, phone);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            finally
            {
                log.Debug("ErrorBuffer: " + cti.errorBuffer);
            }
        }

      


        private void OnTransferredCall(CallsEventArgs e)
        {
            if (TransferredCall != null)
            {
                TransferredCall(this, e);
            }
        }

       

        public void Disconnect()
        {
            cti.OnTransferredCall -= cti_OnTransferredCall;
            cti.OnTransferRequest -= cti_OnTransferRequest;
            cti.OnCompletedCall -= cti_OnCompletedCall;
            cti.OnOutcomingCallAnswer -= cti_OnOutcomingCallAnswer;
            cti.OnOutcomingCall -= cti_OnOutcomingCall;
            cti.OnTransferredCallAnswer -= cti_OnTransferredCallAnswer;
            cti.Disconnect();
            //    State = false;
        }


        //public void Initialize()
        //{
        //    try
        //    {
        //        cti = new CTIControlX();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}






        public void TransferCall(string CallID, string phone)
        {
            cti.Transfer(CallID, phone);
        }


        public string PhoneNumber
        {
            get { return managerphone; }
        }


        public string Prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                _prefix = value;
            }
        }


        public void Dispose()
        {
            Dispose(true /*called by user directly*/);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            Marshal.FinalReleaseComObject(cti);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }


      
    }
}
