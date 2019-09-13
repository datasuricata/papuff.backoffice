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
}
