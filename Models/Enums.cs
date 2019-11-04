using System.ComponentModel.DataAnnotations;

namespace papuff.backoffice.Models {
    public enum RequestMethod {
        Get = 1,
        Post = 2,
        Put = 3,
        Delete = 4,
    }

    public enum UserType {
        [Display(Description = "Cliente")]
        Customer = 1,

        [Display(Description = "Empresa")]
        Enterprise = 2,

        [Display(Description = "Operador")]
        Operator = 3,

        [Display(Description = "Ninja das Sombras")]
        Root = 999,
    }

    public enum MessageType {
        Info = 0,
        Success = 1,
        Exception = 2,
    }

    public enum CurrentStage {
        [Display(Description = "Pendente Aprovação")]
        Pending = 1,

        [Display(Description = "Aprovado")]
        Aproved = 2,

        [Display(Description = "Recusado")]
        Recused = 3,

        [Display(Description = "Bloqueado")]
        Blocked = 4
    }

    public enum BuildingType {

        [Display(Description = "Sem Definição")]
        Undefined = 0,

        [Display(Description = "Casa")]
        House = 1,

        [Display(Description = "Sobrado")]
        Townhouse = 2,

        [Display(Description = "Apartamento")]
        Apartment = 3,

        [Display(Description = "Comercial")]
        Commercial = 4,
    }

    public enum DocumentType {
        [Display(Description = "Registro Geral")]
        RG = 1,

        [Display(Description = "Cadastro de Pessoa Física")]
        CPF = 2,

        [Display(Description = "Cadastro Nacional da Pessoa Jurídica")]
        CNPJ = 3,

        [Display(Description = "Carteira Nacional de Habilitação")]
        CNH = 5,
    }

    public enum PaymentType {
        [Display(Description = "Cartão de Crédito")]
        Credit = 1,

        [Display(Description = "Cartão de Débito")]
        Debit = 2,

        [Display(Description = "Boleto Bancário")]
        BankSlip = 3
    }

    public enum EntryType {
        Ticket = 1,
        OrderPad = 2,
    }
}