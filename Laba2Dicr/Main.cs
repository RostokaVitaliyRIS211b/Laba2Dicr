using MetodKvaina;
using Text;


RenderWindow MainWindow = new(new VideoMode(1280, 720), "Metod Kvaina");

List<Textbox> textboxes = new List<Textbox>();

InitTextboxes(textboxes);

Textbox active = textboxes[1];

Textbox res = new Textbox(ref active);
res.set_string("");

string exp = "x1 *x2 *x3 + !x1 * x2 * x3 + !x3 * x1 * !x2 + x1 * !x2 * x3";

List<List<string>> sohes;
List<List<string>> sohesExp = new List<List<string>>();

sohesExp.Add(new List<string>(new string[] { "x2", "x3" }));
sohesExp.Add(new List<string>(new string[] { "x1", "!x2" }));

List<string> disjuncts = SLE.GetDisjuncts(exp);
List<string> disjunctsExp = new List<string>();

disjunctsExp.Add("x2 * x3 ");
disjunctsExp.Add("x1 * !x2 ");
SLE.OperationOfGluing(out sohes, ref disjuncts);

Clock clock = new Clock();
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
void KeyPressed(object? sender, KeyEventArgs e)
{
    if (e.Code!=Keyboard.Key.Enter)
    {
        char ee = WhatCharItIs(e.Code);
        if (ee!='`')
            active.set_string(active.get_string()+ee);
        return;
    }
    else
    {
        res.set_string(SLE.GetMinimumForm(active.get_string()));
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
        const float otstypOtText = 3;
        Vertex[] vertexes = new Vertex[2];
        vertexes[0] = new Vertex();
        vertexes[1] = new Vertex();
        vertexes[0].Color = Color.Black;
        vertexes[1].Color = Color.Black;
        vertexes[0].Position=new Vector2f(textboxes.Last().GetText().GetGlobalBounds().Left+textboxes.Last().GetText().GetGlobalBounds().Width + otstypOtText, textboxes.Last().GetText().GetGlobalBounds().Top);
        vertexes[1].Position=new Vector2f(textboxes.Last().GetText().GetGlobalBounds().Left+textboxes.Last().GetText().GetGlobalBounds().Width + otstypOtText, textboxes.Last().GetText().GetGlobalBounds().Top + correctCoord);
        window.Draw(vertexes, PrimitiveType.Lines);
    }
    else if(clock.ElapsedTime.AsMilliseconds()>2000)
        clock.Restart();
}
void InitTextboxes(List<Textbox> textboxes)
{
    Textbox textbox = new Textbox();
    textbox.set_string("Введите логическое выражение СДНФ");
    textbox.set_color_text(Color.Black);
    textbox.set_Fill_color_rect(Color.White);
    textbox.set_outline_color_rect(Color.Black);
    textbox.set_outline_thickness_rect(2);
    textbox.set_size_character_text(16);
    textbox.set_size_rect(400, 100);
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

    if (code<=Keyboard.Key.Num9)
    {
        ch = Keyboard.IsKeyPressed(Keyboard.Key.LShift)&&(int)(code)<25 ? (char)((int)gay[(int)code]-32) : gay[(int)code];
    }
    else if (code==Keyboard.Key.Space)
        ch= ' ';
    else if ((int)code==56 || (int)code==68)
        ch='-';
    else if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code==Keyboard.Key.Num8)
        ch='*';
    else if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) && code == Keyboard.Key.Equal)
        ch='+';
    else
        ch='`';
    return ch;
}
