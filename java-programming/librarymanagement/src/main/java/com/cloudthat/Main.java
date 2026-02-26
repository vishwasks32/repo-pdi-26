package com.cloudthat;

import com.cloudthat.library.Library;
import com.cloudthat.models.Book;
import com.cloudthat.utils.CSVReader;


import java.util.List;
import java.util.Optional;
import java.util.function.Consumer;


//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        Library library = new Library();
        CSVReader csvreader = new CSVReader();
        List<Book> books = csvreader.reader("C:\\Users\\VishwasKSingh\\Workspace\\deloitte-workspace\\pdi-workspace-26\\java-programming\\librarymanagement\\src\\main\\java\\com\\cloudthat\\utils\\data.csv");

        if(!books.isEmpty()){
            for(Book b : books){
                library.addBook(b);
            }
        }


//        try {
//            library.addBook(new Book("9780141439518", "Pride and Prejudice", "Jane Austen"));
////            library.addBook(new Book("9780141439518", "Pride and Prejudice", "Jane Austen"));
//            library.addBook(new Book("9781856134033", "Harry Potter", "James Gosling"));
//        } catch (Exception e) {
//            System.out.println("Book you are trying to add already exists");
//        }


        Consumer<Book> printBook = System.out::println;

        List<Book> availableBooks = library.getAvailableBooks();
        availableBooks.forEach(printBook);

        Optional<Book> searchedBook = library.findBookByIsbn("9781856134033");
        searchedBook.ifPresentOrElse(printBook, ()->System.out.println("Book Not Found"));

    }
}