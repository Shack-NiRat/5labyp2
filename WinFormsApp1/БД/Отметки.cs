using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Отметки
{
    public int НомерЗачетнойКнижки { get; set; }

    public int ОценкаГосэкзамен { get; set; }

    public int ОценкаДиплом { get; set; }

    public virtual Студенты НомерЗачетнойКнижкиNavigation { get; set; } = null!;
}
