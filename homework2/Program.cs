using homework2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
#region Eager loading
//using var context = new LibraryDbContext();
//context.Database.EnsureCreated();

//FilterBooksBySubject("Science");
//FilterBooksByCategory("Fiction");
//FilterBooksByAuthor("J.K. Rowling");

//void FilterBooksBySubject(string subjectName)
//{
//    Console.WriteLine($" Books in Subject: {subjectName}");

//    var books = context.Books
//        .Include(b => b.Subject)
//        .Include(b => b.Category)
//        .Include(b => b.Author)
//        .Where(b => b.Subject.Name == subjectName)
//        .ToList();

//    foreach (var book in books)
//    {
//        Console.WriteLine($"- {book.Title} (Author: {book.Author.Name}, Category: {book.Category.Name})");
//    }
//}

//void FilterBooksByCategory(string categoryName)
//{
//    Console.WriteLine($" Books in Category: {categoryName}");

//    var books = context.Books
//        .Include(b => b.Subject)
//        .Include(b => b.Category)
//        .Include(b => b.Author)
//        .Where(b => b.Category.Name == categoryName)
//        .ToList();

//    foreach (var book in books)
//    {
//        Console.WriteLine($"- {book.Title} (Author: {book.Author.Name}, Subject: {book.Subject.Name})");
//    }
//}

//void FilterBooksByAuthor(string authorName)
//{
//    Console.WriteLine($"\ Books by Author: {authorName}");

//    var books = context.Books
//        .Include(b => b.Subject)
//        .Include(b => b.Category)
//        .Include(b => b.Author)
//        .Where(b => b.Author.Name == authorName)
//        .ToList();

//    foreach (var book in books)
//    {
//        Console.WriteLine($"- {book.Title} (Subject: {book.Subject.Name}, Category: {book.Category.Name})");
//    }
//}
#endregion
#region Explicit loading
using var context = new LibraryDbContext();
context.Database.EnsureCreated();

FetchBooksBySubject("Science");
FetchBooksByCategory("Fiction");
FetchBooksByAuthor("J.K. Rowling");

void FetchBooksBySubject(string subjectName)
{
    Console.WriteLine($" Books in Subject: {subjectName}");

    var subject = context.Subjects.FirstOrDefault(s => s.Name == subjectName);

    if (subject == null)
    {
        Console.WriteLine("No books found for this subject.");
        return;
    }


    context.Entry(subject).Collection(s => s.Books).Load();

    foreach (var book in subject.Books)
    {

        context.Entry(book).Reference(b => b.Category).Load();
        context.Entry(book).Reference(b => b.Author).Load();

        Console.WriteLine($"- {book.Title} (Author: {book.Author.Name}, Category: {book.Category.Name})");
    }
}

void FetchBooksByCategory(string categoryName)
{
    Console.WriteLine($" Books in Category: {categoryName}");

    var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);

    if (category == null)
    {
        Console.WriteLine("No books found for this category.");
        return;
    }


    context.Entry(category).Collection(c => c.Books).Load();

    foreach (var book in category.Books)
    {

        context.Entry(book).Reference(b => b.Subject).Load();
        context.Entry(book).Reference(b => b.Author).Load();

        Console.WriteLine($"- {book.Title} (Author: {book.Author.Name}, Subject: {book.Subject.Name})");
    }
}

void FetchBooksByAuthor(string authorName)
{
    Console.WriteLine($" Books by Author: {authorName}");

    var author = context.Authors.FirstOrDefault(a => a.Name == authorName);

    if (author == null)
    {
        Console.WriteLine("No books found for this author.");
        return;
    }


    context.Entry(author).Collection(a => a.Books).Load();

    foreach (var book in author.Books)
    {

        context.Entry(book).Reference(b => b.Subject).Load();
        context.Entry(book).Reference(b => b.Category).Load();

        Console.WriteLine($"- {book.Title} (Subject: {book.Subject.Name}, Category: {book.Category.Name})");
    }
}

#endregion

#region Lazy loading
//using var context = new LibraryDbContext();
//context.Database.EnsureCreated();

#endregion