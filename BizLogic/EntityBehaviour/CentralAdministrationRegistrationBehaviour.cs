using CentralAdministration.Services;
using Labtagon.M42.Common.ServiceContracts;
using Matrix42.Common;
using Matrix42.Hosting.Contracts;
using Matrix42.Persistence;
using Matrix42.Persistence.Contracts;
using System;
using System.Threading;

namespace CentralAdministration.BizLogic.EntityBehaviour
{
    public class CentralAdministrationRegistrationBehaviour : GenericEntityBehavior<DbRecord>
    {
        private ILog logger;
        private IVendorManager vendorManager;
        public CentralAdministrationRegistrationBehaviour(IDependencyResolver resolver)
        {
           logger = resolver.Get<ILog>();
           vendorManager = resolver.Get<IVendorManager>();
        }

            public override void OnSaving(DbRecord dbRecord, BehaviorActionContext context)
            {
     
                try
                {
                string customerNumber = dbRecord.Adapter.GetFragment("CAExtensionClassCentralAdministration").Adapter.GetValue<string>("M42CustomerNumber");
                DbMultiFragment<DbFragment> fragments =  dbRecord.Adapter.GetMultiFragment("CAExtensionCentralAdministrationClassVendorRegistration");

                foreach (DbFragment fragment in fragments)
                {
                    Guid vendorId = fragment.Adapter.GetValue<Guid>("Vendor");
                    string customerReference = fragment.Adapter.GetValue<string>("CustomerReference");
                    int state = fragment.Adapter.GetValue<int>("RegistrationState");
                    if (state == 0) vendorManager.Register(vendorId, String.IsNullOrEmpty(customerReference) ? customerNumber : customerReference);
                    break;
                }



                }
                catch (Exception ex)
                {
                    
                }
            }
        }
 }
