public class BoxInt : Box
{
    public char operat;

    private void Start()
    {
        setValue(value);
        textValue.text = operat.ToString() + textValue.text;
    }
}
