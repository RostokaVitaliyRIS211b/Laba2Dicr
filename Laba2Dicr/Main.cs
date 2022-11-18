using MetodKvaina;
using Text;
using System.Diagnostics;

RenderWindow MainWindow = new(new VideoMode(1280, 720), "Metod Kvaina");

List<Textbox> textboxes = new List<Textbox>();

int insertIndex = 0;

InitTextboxes(textboxes);

Textbox active = textboxes[1];

Textbox res = new Textbox(ref active);
res.set_string("");
res.set_size_rect(400, 100);
res.set_pos(202, 52);
Clock clock = new Clock();

//SLE.GetTime(" x * y * z +  x * y * !z +  x * !y * !z + !x * !y * !z +  !x * y * z +  !x * !y * z ");
//Stopwatch stopwatch = new Stopwatch();
//stopwatch.Start();
//SDNF.GetSDNF("( (x * y) -> !z ) * ( (!y -> z) + ( (x !* z -> !x) == y) )");
//stopwatch.Stop();

MainWindow.MouseButtonPressed += MouseButtonPressed;
MainWindow.MouseButtonReleased += MouseButtonReleased;
MainWindow.MouseMoved += MouseMoved;
MainWindow.KeyPressed += KeyPressed;
MainWindow.MouseWheelScrolled += MouseWheelScrolled;
MainWindow.Closed += WindowClosed;

while (MainWindow.IsOpen)
{
    MainWindow.Clear(Color.White);
    MainWindow.DispatchEvents();
    DrawTextbox(MainWindow, textboxes,clock);
    MainWindow.Draw(res);
    MainWindow.Display();
}

void MouseButtonPressed(object? sender, MouseButtonEventArgs e)
{

}
void MouseButtonReleased(object? sender, MouseButtonEventArgs e)
{

}
void MouseMoved(object? sender, MouseMoveEventArgs e)
{

}
void KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
{
    if(Keyboard.IsKeyPressed(Keyboard.Key.LControl) && Keyboard.IsKeyPressed(Keyboard.Key.V))
    {
        active.set_string(Clipboard.Contents);
        return;
    }
    else if(e.Code == Keyboard.Key.Left)
    {
        if(insertIndex<active.get_string().Length)
            ++insertIndex;
        return;
    }
    else if(e.Code == Keyboard.Key.Right)
    {
        if (insertIndex>0)
            --insertIndex;
        return;
    }
    else if (e.Code!=Keyboard.Key.Enter && e.Code != Keyboard.Key.Backspace && e.Code!=Keyboard.Key.LControl)
    {
        char ee = WhatCharItIs(e.Code);
        if (ee!='`')
            active.set_string(active.get_string().Insert(active.get_string().Length-insertIndex,ee.ToString()));
        return;
    }
    else if(e.Code==Keyboard.Key.Enter)
    {
        string sdnf = SDNF.GetSDNF(active.get_string());
        res.set_string(SLE.GetMinimumForm(sdnf));
    }
    else if(e.Code == Keyboard.Key.Backspace)
    {
        if(active.get_string().Length>=1)
            active.set_string(active.get_string().Remove(active.get_string().Length-insertIndex-1,1));
    }
}
void MouseWheelScrolled(object? sender, MouseWheelScrollEventArgs e)
{

}
void WindowClosed(object? sender,EventArgs e)
{
    Window window = (Window)sender;
    window.Close();
}
void DrawTextbox(RenderWindow window,List<Textbox> textboxes,Clock clock)
{
    foreach (Textbox textbox1 in textboxes)
        window.Draw(textbox1);
    if (clock.ElapsedTime.AsMilliseconds()>1000 && clock.ElapsedTime.AsMilliseconds()<2000)
    {
        float correctCoord = textboxes.Last().GetText().GetGlobalBounds().Height>0 ? textboxes.Last().GetText().GetGlobalBounds().Height : textboxes.Last().GetText().CharacterSize;
        const float otstypOtText = 1.2f;
        Vertex[] vertexes = new Vertex[2];
        vertexes[0] = new Vertex();
        vertexes[1] = new Vertex();
        vertexes[0].Color = SFML.Graphics.Color.Black;
        vertexes[1].Color = SFML.Graphics.Color.Black;
        vertexes[0].Position=new Vector2f(textboxes.Last().GetText().GetGlobalBounds().Left+textboxes.Last().GetText().GetGlobalBounds().Width + otstypOtText - insertIndex*textboxes.Last().GetText().CharacterSize/1.875f, textboxes.Last().GetText().GetGlobalBounds().Top-1);
        vertexes[1].Position=new Vector2f(textboxes.Last().GetText().GetGlobalBounds().Left+textboxes.Last().GetText().GetGlobalBounds().Width + otstypOtText - insertIndex*textboxes.Last().GetText().CharacterSize/1.875f, textboxes.Last().GetText().GetGlobalBounds().Top + correctCoord+1);
        window.Draw(vertexes, PrimitiveType.Lines);
    }
    else if(clock.ElapsedTime.AsMilliseconds()>2000)
        clock.Restart();
}
void InitTextboxes(List<Textbox> textboxes)
{
    Textbox textbox = new Textbox();
    textbox.set_string("Введите логическое выражение");
    textbox.set_color_text(SFML.Graphics.Color.Black);
    textbox.set_Fill_color_rect(SFML.Graphics.Color.White);
    textbox.set_outline_color_rect(SFML.Graphics.Color.Black);
    textbox.set_outline_thickness_rect(2);
    textbox.set_size_character_text(20);
    textbox.set_size_rect(800, 100);
    textbox.set_pos(640, 260);
    textboxes.Add(textbox);
    textbox = new Textbox(ref textbox);
    textbox.set_pos(640, 360);
    textbox.set_string("");
    textboxes.Add(textbox);
}
char WhatCharItIs(Keyboard.Key code)
{
    char ch = '0';
    string gay = "abcdefghijklmnopqrstuvwxyz0123456789";
    //( x * y -> y*z ) -> z*x 

    if (code<=Keyboard.Key.Num9)
    {
        ch = Keyboard.IsKeyPressed(Keyboard.Key.LShift)&&(int)(code)<25 ? (char)((int)gay[(int)code]-32) : gay[(int)code];
    }
    else if (code==Keyboard.Key.Space)
        ch= ' ';
    else if ((int)code==56 || (int)code==68)
        ch='-';
    else if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code == Keyboard.Key.Equal)
        ch='+';
    else
        ch='`';
    if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code==Keyboard.Key.Num8)
        ch='*';
    if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code==Keyboard.Key.Num1)
        ch='!';
    if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code==Keyboard.Key.Num9)
        ch='(';
    if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code==Keyboard.Key.Num0)
        ch=')';
    if (code==Keyboard.Key.Period)
        ch='>';
    if (code == Keyboard.Key.Equal && !Keyboard.IsKeyPressed(Keyboard.Key.LShift))
        ch = '=';
    return ch;
}
