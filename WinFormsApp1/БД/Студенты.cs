using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Студенты
{
    public int НомерЗачетнойКнижки { get; set; }

    public string Фио { get; set; } = null!;

    public string Факультет { get; set; } = null!;

    public string Группа { get; set; } = null!;

    public virtual ICollection<ВыбранныеТемы> ВыбранныеТемыs { get; set; } = new List<ВыбранныеТемы>();

    public virtual Отметки? Отметки { get; set; }
}
