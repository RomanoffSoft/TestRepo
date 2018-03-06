using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Technology.VoIP
{
    public class VoIPSettings : ConfigurationSection
    {
        private const string m_Provider = "Provider";
        private const string m_lstNumber = "Number";
        private const string m_ConnectOnStartup = "ConnectOnStartup";
        private const string m_active = "Active";
        private const string m_Prefix = "Prefix_OUT";
        private const string m_returnnumber = "ReturnNumber";
        private const string m_timeout = "CallTimeout";
        private const string m_Prefix_IN = "Prefix_IN";

        [ConfigurationProperty(m_Provider)]
        public string Provider
        {
            get
            {
                return (string)this[m_Provider];
            }
            set
            {
                this[m_Provider] = value;
            }
        }
        [ConfigurationProperty(m_lstNumber)]
        public string Number
        {
            get
            {
                return (string)this[m_lstNumber];
            }
            set
            {
                this[m_lstNumber] = value;
            }
        }
        [ConfigurationProperty(m_ConnectOnStartup)]
        public bool ConnectOnStartup
        {
            get
            {
                //if ((string)this[m_ConnectOnStartup] == "True")
                //    return true;
                //else
                //    return false;

                return (bool)this[m_ConnectOnStartup];
            }
            set
            {
                //if (value)               
                //this[m_ConnectOnStartup] = "True";
                //else
                //this[m_ConnectOnStartup] = "False";

                this[m_ConnectOnStartup] = value;
            }
        }
        [ConfigurationProperty(m_active)]
        public bool Active
        {
            get
            {
                return (bool)this[m_active];
            }
            set
            {
                this[m_active] = value;
            }
        }

        /// <summary>
        /// Префикс для городских номеров при исходящих вызовах (например,для исходящего звонка необходимо сначала набирать 8 или 9,
        /// и это нужно добавлять к номеру, чтобы успешно позвонить на него
        /// </summary>
        [ConfigurationProperty(m_Prefix)]
        public string Prefix
        {
            get { return (string)this[m_Prefix]; }
            set { this[m_Prefix] = value; }
        }

        /// <summary>
        /// Префикс для городских номеров при входящих вызовах (например, АТС может возвращать номер формата "+7XXXXXXXXXXX",
        /// в то время, когда в Профиле номер хранятся без префиксов
        /// </summary>

        [ConfigurationProperty(m_Prefix_IN)]
        public string Prefix_IN
        {
            get { return (string)this[m_Prefix_IN]; }
            set { this[m_Prefix_IN] = value; }
        }



        /// <summary>
        /// Таймаут для исходящего вызова (на случай, если провайдер из-за сбоя не присылает никаких уведомлений о совершаемом исходящем вызове)
        /// </summary>
        [ConfigurationProperty(m_timeout)]
        public int TimeOut
        {
            get { return (int)this[m_timeout]; }
            set { this[m_timeout] = value; }
        }



        [ConfigurationProperty(m_returnnumber)]
        public string ReturnNumber
        {
            get { return (string)this[m_returnnumber]; }
            set { this[m_returnnumber] = value; }
        }

        public class ConfgurationClassLoader : ConfigurationSection, IEnumerable<IVoIP>
        {
            [ConfigurationProperty("VoIPClients")]
            public ClientsCollection Clients
            {
                get { return ((ClientsCollection)(base["VoIPClients"])); }
            }

            public IEnumerator<IVoIP> GetEnumerator()
            {
                return (IEnumerator<IVoIP>)Clients.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return Clients.GetEnumerator();
            }
        }

        [ConfigurationCollection(typeof(ClientElement))]
        public class ClientsCollection : ConfigurationElementCollection , IEnumerable<IVoIP>
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new ClientElement();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return((ClientElement)(element)).ClientType;
            }

            public ClientElement this[int index]
            {
                get { return (ClientElement)BaseGet(index); }
            }

            public new IEnumerator<IVoIP> GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public class ClientElement : ConfigurationElement
        {
            [ConfigurationProperty("name")]
            public string ClientType
            {
                get { return (string)(base["name"]); }
                set { base["name"] = value; }
            }

            [ConfigurationProperty("number")]
            public string Number
            {
                get { return ((string)(base["number"])); }
                set { base["number"] = value; }
            }

            //[ConfigurationProperty("class")]
            //public string Priority
            //{
            //    get { return ((string)(base["class"])); }
            //    set { base["class"] = value; }
            //}

        }
    }
}
