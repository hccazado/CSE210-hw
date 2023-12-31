class ReflectingActivity: Activity
//Inherits from Activity Class
{
    private List<string> _messages;

    private List<string> _questions;

    private int _answers;

    public ReflectingActivity(int duration)
    {
        SetName("Mindful Reflecting");

        SetDescription("Focusing on moments you used your strength and resilience helps improve your"+
                        " self-awareness of your power to accomplish great things.");
        
        SetDuration(duration);

        SetQuestions();

        SetMessages();

        _answers = 0;
    }

    private string RandomMessage()
    //returns a random string from _messages list
    {
        Random random = new Random();

        int index = random.Next(0, _messages.Count);

        string prompt = _messages[index];

        return prompt;
    }

    private string RandomQuestion()
    //returns a random string from _questions list and removes the returned question from referred list
    {
        Random random = new Random();

        if (_questions.Count == 0)
        {
            SetQuestions();
        }

        int index = random.Next(0, _messages.Count);

        string question = _questions[index];

        _questions.RemoveAt(index);

        return question;
        
    }

    private void SetQuestions()
    //Populates _questions list
    {
        _questions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this experience successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };
    }

    private void SetMessages()
    //Populates _messages list
    {
        _messages = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    protected override string GetStatistics()
    //overrides method from Activity class
    {
        return $"You answered: {_answers} questions in {GetDuration()} seconds.";
    }

    public void MindfulReflecting()
    //Displays welcome message and a random reflective message. Display random questions, and dd user input to _answers list
     //and Prints getstatistics method return
    {
        Console.Clear();

        Console.WriteLine(WelcomeMessage());
        
        PreparingTimer();
        
        Console.WriteLine(RandomMessage());

        Spinner(5);
        
        DateTime currentTime = DateTime.Now;
        
        DateTime stopTime = currentTime.AddSeconds(GetDuration());
        
        while(DateTime.Now < stopTime)
        {
            Console.WriteLine(RandomQuestion());

            Console.Write("> ");

            string answer = Console.ReadLine();

            _answers++;
        }

        Console.WriteLine($"\n{GetStatistics()}");

        Console.WriteLine($"\n{EndMessage()}");

        Spinner(5);
    }

}