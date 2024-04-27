namespace Shaker.Domain.Models.ShakerOptionsModel;

public class CreateShakerOptionsModel
{
    public int RunningTime { get; set; } // 30 dakika çalışsın bilgisi
    public bool IsStoped { get; set; } // Durdurma Bilgisi
    public DateTime StopedTime { get; set; } // Şu kadar zaman sonra dursun bilgisi
    public int ShakerId { get; set; } // Hangi çalkalayıcıya ait olduğu bilgisi
}
