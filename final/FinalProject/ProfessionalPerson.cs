using System.Reflection.Metadata;

class ProfessionalPerson : Person
{
    private string _professionalRegister;
    private string _professionalActivity;
    private bool _isActive;

    public ProfessionalPerson(string name, string document, string docType, DateOnly dob, string register, string professionalActivity, bool isActive = false) :base (name, document, docType, dob)
    {
        _professionalRegister = register;
        _professionalActivity = professionalActivity;
        _isActive = isActive;
    }

    public bool isActive()
    {
        return _isActive;
    }

    public void SetActive()
    {
        _isActive = true;
    }

    public void UnsetActive()
    {
        _isActive = false;
    }

    override public string GetPersonSpecificData()
    {
        if(_isActive)
        {
            return $"{_professionalActivity}: {_professionalRegister} - Active Health promoter";
        }
        else
        {
            return $"{_professionalActivity}: {_professionalRegister} - Inactive Health promoter";
        }
        
    }
}