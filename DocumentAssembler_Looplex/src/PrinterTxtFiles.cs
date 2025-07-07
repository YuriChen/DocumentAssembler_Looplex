public class PrinterTxtFiles : IPrinter
{
    public string? downloadsPath { get; set; }
    public string? folderName { get; set; }

    public PrinterTxtFiles (string? downloadsPath = null, string? folderName = null)
    {
        this.downloadsPath = (!string.IsNullOrEmpty(downloadsPath) ? downloadsPath 
                                : Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"); // Obter o caminho da pasta Downloads do usuário
        this.folderName = (!string.IsNullOrEmpty(folderName) ? folderName : "documentsLooplex");
    }

    public void printNode(Node node, int level)
    {
        string fileName = $"{node.id}.txt";

        // Criar o caminho completo para a nova pasta
        string fullFolderPath = Path.Combine(downloadsPath, folderName);

        // Verificar se a pasta já existe. Cria a pasta se não existir.
        if (!Directory.Exists(fullFolderPath))
        {
            Directory.CreateDirectory(fullFolderPath);
        }

        // Criar o caminho completo para o arquivo
        string filePath = Path.Combine(fullFolderPath, fileName);

        File.WriteAllText(filePath, node.text);
    }
}

