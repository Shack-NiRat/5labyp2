using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class ВыбранныеТемы
{
    public string Тема { get; set; } = null!;

    public int НомерЗачетнойКнижки { get; set; }

    public virtual Студенты НомерЗачетнойКнижкиNavigation { get; set; } = null!;

    public virtual ICollection<Темы> Темыs { get; set; } = new List<Темы>();
}
