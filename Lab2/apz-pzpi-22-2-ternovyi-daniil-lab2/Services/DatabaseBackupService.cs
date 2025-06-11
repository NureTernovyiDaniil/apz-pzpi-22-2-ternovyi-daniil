using System.Data.SqlClient;

public class DatabaseBackupService
{
    private readonly string _connectionString;

    public DatabaseBackupService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<string> CreateBackupAsync()
    {
        var databaseName = new SqlConnectionStringBuilder(_connectionString).InitialCatalog;
        var fileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        var backupFolder = Path.Combine(Path.GetTempPath(), "DbBackups");

        Directory.CreateDirectory(backupFolder);

        var backupFilePath = Path.Combine(backupFolder, fileName);

        var backupSql = $@"
            BACKUP DATABASE [{databaseName}]
            TO DISK = @BackupFilePath
            WITH FORMAT,
                 MEDIANAME = 'DbBackups',
                 NAME = 'Full Backup of {databaseName}';";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(backupSql, connection);
        command.Parameters.AddWithValue("@BackupFilePath", backupFilePath);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        return backupFilePath;
    }
}
