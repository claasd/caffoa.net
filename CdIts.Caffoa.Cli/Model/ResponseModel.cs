namespace CdIts.Caffoa.Cli.Model;

public class ResponseModel
{
    public int Code { get; }
    public string? TypeName { get; set; }
    public bool Unknown { get; set; }

    public ResponseModel(string code)
    {
        Code = int.Parse(code);
    }
}