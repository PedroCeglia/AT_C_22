using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly string _filesPath;

        public ViewNotesModel(IWebHostEnvironment environment)
        {
            _filesPath = Path.Combine(environment.WebRootPath, "files");
        }

        [BindProperty]
        public string NoteContent { get; set; }

        [BindProperty]
        public string NoteName { get; set; }

        public List<string> FileNames { get; set; }

        public string SelectedNoteContent { get; set; }

        public IActionResult OnGet(string fileName = null)
        {
            Console.WriteLine($"OnGet chamado, fileName={fileName}");
            try
            {
                if (!Directory.Exists(_filesPath))
                {
                    Directory.CreateDirectory(_filesPath);
                }

                FileNames = Directory.GetFiles(_filesPath, "*.txt")
                    .Select(Path.GetFileName)
                    .ToList();

                if (!string.IsNullOrEmpty(fileName))
                {
                    var filePath = Path.Combine(_filesPath, fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        SelectedNoteContent = System.IO.File.ReadAllText(filePath);
                        Console.WriteLine($"Arquivo lido: {fileName}");
                    }
                    else
                    {
                        Console.WriteLine($"Arquivo não encontrado: {fileName}");
                        return NotFound();
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no OnGet: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Erro ao listar ou ler arquivos.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"OnPost chamado, NoteName={NoteName}, NoteContent={NoteContent}");
            if (string.IsNullOrWhiteSpace(NoteName) || string.IsNullOrWhiteSpace(NoteContent))
            {
                ModelState.AddModelError(string.Empty, "Nome e conteúdo da nota são obrigatórios.");
                FileNames = Directory.GetFiles(_filesPath, "*.txt")
                    .Select(Path.GetFileName)
                    .ToList();
                return Page();
            }

            try
            {
                var safeFileName = Path.GetFileNameWithoutExtension(NoteName) + ".txt";
                var filePath = Path.Combine(_filesPath, safeFileName);

                await System.IO.File.WriteAllTextAsync(filePath, NoteContent);
                Console.WriteLine($"Arquivo salvo: {safeFileName}");

                return RedirectToPage("./ViewNotes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Erro ao salvar a nota.");
                FileNames = Directory.GetFiles(_filesPath, "*.txt")
                    .Select(Path.GetFileName)
                    .ToList();
                return Page();
            }
        }
    }
}
