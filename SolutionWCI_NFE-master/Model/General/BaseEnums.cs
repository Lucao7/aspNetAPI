using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.General
{
    public class BaseEnums
    {
        public enum EEnvironment
        {
            [Display(Name = "LBL_SELECT", ResourceType = typeof(Resource.Resource))]
            Select = 0,
            [Display(Name = "LBL_PRODUCTION", ResourceType = typeof(Resource.Resource))]
            Production = 1,
            [Display(Name = "LBL_HOMOLOGATION", ResourceType = typeof(Resource.Resource))]
            homologation = 2
        }

        public enum ERegime
        {
            [Display(Name = "LBL_NORMALTAXATION", ResourceType = typeof(Resource.Resource))]
            NormalTaxation = 1,
            [Display(Name = "LBL_SIMPLENATIONAL", ResourceType = typeof(Resource.Resource))]
            SimpleNational = 2
        }

        public enum EModalityDeterminationICMS
        {
            [Display(Name = "LBL_MARGINVALUEAGGREGATED", ResourceType = typeof(Resource.Resource))]
            MarginValueAggregated = 1,
            [Display(Name = "LBL_CUSTOMSTARIFF", ResourceType = typeof(Resource.Resource))]
            CustomsTariff = 2,
            [Display(Name = "LBL_PRICETABULATEDMAX", ResourceType = typeof(Resource.Resource))]
            PriceTabulatedMax = 3,
            [Display(Name = "LBL_VALUEAGGREGATED", ResourceType = typeof(Resource.Resource))]
            ValueAggregated = 4
        }

        public enum EModalityDeterminationICMS_ST
        {
            [Display(Name = "LBL_MARGINVALUEAGGREGATED", ResourceType = typeof(Resource.Resource))]
            MarginValueAggregated = 1,
            [Display(Name = "LBL_CUSTOMSTARIFF", ResourceType = typeof(Resource.Resource))]
            CustomsTariff = 2,
            [Display(Name = "LBL_PRICETABLEMAXIMUMSUGGESTED", ResourceType = typeof(Resource.Resource))]
            PriceTableMaximumSuggested = 3,
            [Display(Name = "LBL_NEGATIVELIST", ResourceType = typeof(Resource.Resource))]
            NegativeList = 4,
            [Display(Name = "LBL_POSITIVELIST", ResourceType = typeof(Resource.Resource))]
            PositiveList = 5,
            [Display(Name = "LBL_NEUTRALLIST", ResourceType = typeof(Resource.Resource))]
            NeutralList = 6
        }

        public enum ETypeCalculation
        {
            [Display(Name = "LBL_PERCENTAGE", ResourceType = typeof(Resource.Resource))]
            Percentage = 0,
            [Display(Name = "LBL_INVALUE", ResourceType = typeof(Resource.Resource))]
            InValue = 1
        }

        // Tipo de Documento
        public enum ETypeDocument
        {
            [Display(Name = "LBL_INPUT", ResourceType = typeof(Resource.Resource))]
            Input = 0,
            [Display(Name = "LBL_EXIT", ResourceType = typeof(Resource.Resource))]
            Exit = 1
        }

        // Forma de Pagamento
        public enum EPaymentFom
        {
            [Display(Name = "LBL_CASHPAYMENT", ResourceType = typeof(Resource.Resource))]
            CashPayment = 0,
            [Display(Name = "LBL_DEFERREDPAYMENT", ResourceType = typeof(Resource.Resource))]
            DeferredPayment = 1,
            [Display(Name = "LBL_OTHERS", ResourceType = typeof(Resource.Resource))]
            Others = 2
        }

        // Forma de Emissão
        public enum EEmissionForm
        {
            [Display(Name = "LBL_SELECT", ResourceType = typeof(Resource.Resource))]
            Select = 0,
            [Display(Name = "LBL_NORMAL", ResourceType = typeof(Resource.Resource))]
            Normal = 1,
            [Display(Name = "LBL_FSIA", ResourceType = typeof(Resource.Resource))]
            FsIa = 2,
            [Display(Name = "LBL_VIAEPEC", ResourceType = typeof(Resource.Resource))]
            viaEpec = 3,
            [Display(Name = "LBL_FSDA", ResourceType = typeof(Resource.Resource))]
            FsDa = 4,
            [Display(Name = "LBL_SVCAN", ResourceType = typeof(Resource.Resource))]
            SvcAn = 5,
            [Display(Name = "LBL_SVCRS", ResourceType = typeof(Resource.Resource))]
            SvcRs = 6
        }

        // Finalidade de Emissão
        public enum EEmissionPurpose
        {
            [Display(Name = "LBL_SELECT", ResourceType = typeof(Resource.Resource))]
            Select = 0,
            [Display(Name = "LBL_INVOCENORMAL", ResourceType = typeof(Resource.Resource))]
            Normal = 1,
            [Display(Name = "LBL_INVOCECOMPLEMENTARY", ResourceType = typeof(Resource.Resource))]
            Complementary = 2,
            [Display(Name = "LBL_INVOCEADJUSTMENT", ResourceType = typeof(Resource.Resource))]
            Adjustment = 3,
            [Display(Name = "LBL_INVOCEMERCHANDISERETURN", ResourceType = typeof(Resource.Resource))]
            MerchandiseReturn = 4
        }

        // Tipo de Impressão
        public enum ETypePrint
        {
            [Display(Name = "LBL_SELECT", ResourceType = typeof(Resource.Resource))]
            Select = 0,
            [Display(Name = "LBL_PORTRAIT", ResourceType = typeof(Resource.Resource))]
            Portrait = 1,
            [Display(Name = "LBL_LANDSCAPE", ResourceType = typeof(Resource.Resource))]
            Landscape = 2
        }

        // Consumidor Final
        public enum EConsumerFinal
        {
            [Display(Name = "LBL_YES", ResourceType = typeof(Resource.Resource))]
            Yes = 0,
            [Display(Name = "LBL_NO", ResourceType = typeof(Resource.Resource))]
            No = 1
        }

        // Destino da Operação
        public enum EDestinationOperation
        {
            [Display(Name = "LBL_SELECT", ResourceType = typeof(Resource.Resource))]
            Select = 0,
            [Display(Name = "LBL_INTERNAL", ResourceType = typeof(Resource.Resource))]
            Internal = 1,
            [Display(Name = "LBL_INTERSTATE", ResourceType = typeof(Resource.Resource))]
            Interstate = 2,
            [Display(Name = "LBL_WITHEXTERIOR", ResourceType = typeof(Resource.Resource))]
            Exterior = 3
        }

        // Tipo de Atendimento
        public enum ECustomerService
        {
            [Display(Name = "LBL_NOTAPPLICABLE", ResourceType = typeof(Resource.Resource))]
            NotApplicable = 0,
            [Display(Name = "LBL_OPERATIONINPRESENCE", ResourceType = typeof(Resource.Resource))]
            OperationInPresence = 1,
            [Display(Name = "LBL_OPERATIONNOTPRESENCEINTERNET", ResourceType = typeof(Resource.Resource))]
            OpeartionInternet = 2,
            [Display(Name = "LBL_OPERATIONNOTPRESENCETELEMARKETING", ResourceType = typeof(Resource.Resource))]
            OperationTelemarketing = 3,
            [Display(Name = "LBL_OPERATIONNOTPRESENCEOTHERS", ResourceType = typeof(Resource.Resource))]
            OperationNotPresenceOthers = 9
        }

        // Modalidade de Frete
        public enum EFreightMode
        {
            [Display(Name = "LBL_BEHALFISSUER", ResourceType = typeof(Resource.Resource))]
            BehalfIssuer = 0,
            [Display(Name = "LBL_BEHALFSENDER", ResourceType = typeof(Resource.Resource))]
            BehalfSender = 1,
            [Display(Name = "LBL_BEHALFTHRIRDPARTIES", ResourceType = typeof(Resource.Resource))]
            BehalfThirdParties = 2,
            [Display(Name = "LBL_NOFREIGHT", ResourceType = typeof(Resource.Resource))]
            NoFreight = 9
        }

        public enum EInvoiceStatus
        {
            [Display(Name = "LBL_TYPING", ResourceType = typeof(Resource.Resource))]
            Typing = 0,
            [Display(Name = "LBL_PROCESSING", ResourceType = typeof(Resource.Resource))]
            Processing = 1,
            [Display(Name = "LBL_REJECTED", ResourceType = typeof(Resource.Resource))]
            Rejected = 2,
            [Display(Name = "LBL_DENEGATION", ResourceType = typeof(Resource.Resource))]
            Denegation = 3,
            [Display(Name = "LBL_CANCELED", ResourceType = typeof(Resource.Resource))]
            Canceled = 4,
            [Display(Name = "LBL_UNUSABLED", ResourceType = typeof(Resource.Resource))]
            Unusabled = 5,
            [Display(Name = "LBL_AUTHORIZED", ResourceType = typeof(Resource.Resource))]
            Authorized = 6
        }

        public enum EModelInvoiceRelatedCoupon
        {
            [Display(Name = "LBL_TWOB", ResourceType = typeof(Resource.Resource))]
            TwoB = 0,
            [Display(Name = "LBL_TWOC", ResourceType = typeof(Resource.Resource))]
            TwoC = 1,
            [Display(Name = "LBL_TWOD", ResourceType = typeof(Resource.Resource))]
            TwoD = 2
        }

        public enum ETypeInvoiceRelated
        {
            [Display(Name = "LBL_NFE", ResourceType = typeof(Resource.Resource))]
            nfe = 0,
            [Display(Name = "LBL_CTE", ResourceType = typeof(Resource.Resource))]
            cte = 1,
            [Display(Name = "LBL_INVOICEFISCAL", ResourceType = typeof(Resource.Resource))]
            invoice = 2
        }

        public enum EModelInvoiceRelatedProducer
        {
            [Display(Name = "LBL_ONE", ResourceType = typeof(Resource.Resource))]
            one = 0,
            [Display(Name = "LBL_FOUR", ResourceType = typeof(Resource.Resource))]
            four = 1
        }
    }
}
