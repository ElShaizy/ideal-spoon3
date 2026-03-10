using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- TRAAGENT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAagent.FldCodagent)
                .From(CSGenioAagent.AreaAGENT)
                .Where(CriteriaSet.And().In(CSGenioAagent.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAagent model = new CSGenioAagent(user);
                model.ValCodagent = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRABroker --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAbroker.FldCodbroker)
                .From(CSGenioAbroker.AreaBROKER)
                .Where(CriteriaSet.And().In(CSGenioAbroker.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAbroker model = new CSGenioAbroker(user);
                model.ValCodbroker = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRACOUNTRY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcountry.FldCodcountry)
                .From(CSGenioAcountry.AreaCOUNTRY)
                .Where(CriteriaSet.And().In(CSGenioAcountry.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcountry model = new CSGenioAcountry(user);
                model.ValCodcountry = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRAMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRACITY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcity.FldCodcity)
                .From(CSGenioAcity.AreaCITY)
                .Where(CriteriaSet.And().In(CSGenioAcity.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcity model = new CSGenioAcity(user);
                model.ValCodcity = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRAproperties --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAproperties.FldCodproperties)
                .From(CSGenioAproperties.AreaPROPERTIES)
                .Where(CriteriaSet.And().In(CSGenioAproperties.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAproperties model = new CSGenioAproperties(user);
                model.ValCodproperties = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRACONTACT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcontact.FldCodcontact)
                .From(CSGenioAcontact.AreaCONTACT)
                .Where(CriteriaSet.And().In(CSGenioAcontact.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcontact model = new CSGenioAcontact(user);
                model.ValCodcontact = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- TRAPHOTO_ALBUM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAphoto_album.FldCodphoto_album)
                .From(CSGenioAphoto_album.AreaPHOTO_ALBUM)
                .Where(CriteriaSet.And().In(CSGenioAphoto_album.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAphoto_album model = new CSGenioAphoto_album(user);
                model.ValCodphoto_album = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- TRAmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAmem")
                .Where(CriteriaSet.And().In("TRAmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAcfg")
                .Where(CriteriaSet.And().In("TRAcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAlstusr")
                .Where(CriteriaSet.And().In("TRAlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAlstcol")
                .Where(CriteriaSet.And().In("TRAlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAlstren")
                .Where(CriteriaSet.And().In("TRAlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAusrwid")
                .Where(CriteriaSet.And().In("TRAusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAusrcfg")
                .Where(CriteriaSet.And().In("TRAusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAusrset")
                .Where(CriteriaSet.And().In("TRAusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAwkfact")
                .Where(CriteriaSet.And().In("TRAwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAwkfcon")
                .Where(CriteriaSet.And().In("TRAwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAwkflig")
                .Where(CriteriaSet.And().In("TRAwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAwkflow")
                .Where(CriteriaSet.And().In("TRAwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAnotifi")
                .Where(CriteriaSet.And().In("TRAnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAprmfrm")
                .Where(CriteriaSet.And().In("TRAprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAscrcrd")
                .Where(CriteriaSet.And().In("TRAscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRApostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRApostit")
                .Where(CriteriaSet.And().In("TRApostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAalerta")
                .Where(CriteriaSet.And().In("TRAalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAaltent")
                .Where(CriteriaSet.And().In("TRAaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAtalert")
                .Where(CriteriaSet.And().In("TRAtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAdelega")
                .Where(CriteriaSet.And().In("TRAdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRATABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRATABDINAMIC")
                .Where(CriteriaSet.And().In("TRATABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAaltran")
                .Where(CriteriaSet.And().In("TRAaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAworkflowtask")
                .Where(CriteriaSet.And().In("TRAworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- TRAworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("TRAworkflowprocess")
                .Where(CriteriaSet.And().In("TRAworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}