namespace sharp_lab_1
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}