using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using Opc.Ua;
using Opc;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Threading;

namespace OUA1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }
        Session m_session;

        ApplicationInstance instance = new ApplicationInstance()
        {
            ApplicationName = "Simulator_MPSA",
            ApplicationType = ApplicationType.Client,
            ConfigSectionName = "Simulator_MPSA"

        };
        ApplicationConfiguration config;

        ConfiguredEndpoint endpoint = new ConfiguredEndpoint();
        string sessionName = "Simulator_MPSA";

        async Task CreateSession()
        {
            config = await instance.LoadApplicationConfiguration(false);

            instance.ApplicationConfiguration = config;

            bool haveAppCertificate = await instance.CheckApplicationInstanceCertificate(false, 0);

            if (haveAppCertificate)
            {
                config.CertificateValidator.CertificateValidation += CertificateValidator_CertificateValidation;
            }
            config.ApplicationUri = X509Utils.GetApplicationUriFromCertificate(config.SecurityConfiguration.ApplicationCertificate.Certificate);

            var selectedEndpoint = CoreClientUtils.SelectEndpoint("opc.tcp://10.155.23.64:49152/OPCUAServerExpert", haveAppCertificate, 15000);

            Debug.WriteLine(selectedEndpoint.SecurityPolicyUri);


            var endPointConfig = EndpointConfiguration.Create(config);
            var endPoint = new ConfiguredEndpoint(null, selectedEndpoint, endPointConfig);

            endpoint.UpdateBeforeConnect = false;
            UserIdentity identity = new UserIdentity(new AnonymousIdentityToken());
            


            m_session = await Session.Create(config, endpoint, false, "", 60000, identity ,null);
        }

        private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            if (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = true;
                if (true)
                {
                    Console.WriteLine("Accepted Certificate: {0}", e.Certificate.Subject);
                }
                else
                {
                    Console.WriteLine("Rejected Certificate: {0}", e.Certificate.Subject);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSession().Wait();
            
          //  m_session.Open(sessionName, new UserIdentity(new AnonymousIdentityToken()));
        }

      
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            m_session = null;
        }
    }
}