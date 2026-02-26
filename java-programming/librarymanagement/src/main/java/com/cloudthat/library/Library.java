package com.cloudthat.library;

import com.cloudthat.exceptions.BookExistsException;
import com.cloudthat.models.Book;

import java.util.*;
import java.util.concurrent.CompletableFuture;
import java.util.stream.Collectors;

public class Library {

    // Using is HashMap or HashSet is much faster or efficient
    private Map<String, Book> bookMap;
    private Set<String> uniqueIsbns;
    public Library(){
        // Create a Dummy book initially
        bookMap = new HashMap<>();
        uniqueIsbns = new HashSet<>();
    }

    public void addBook(Book book){

        if(bookMap.containsKey(book.getIsbn())){
            throw new BookExistsException("Book Exists in Library");
        }
        bookMap.putIfAbsent(book.getIsbn(), book);
    }

    public Optional<Book> findBookByIsbn(String isbn){
        return Optional.ofNullable(bookMap.get(isbn));
    }

    public List<Book> getAvailableBooks(){
        return bookMap.values().stream()
                .filter(Book::isAvaliable)
                .collect(Collectors.toList());
    }

    public CompletableFuture<List<Book>> searchByTitleAsync(String keyword){
        return CompletableFuture.supplyAsync(()-> {
            try{
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
            return bookMap.values().stream()
                    .filter(book -> book.getTitle().toLowerCase().contains(keyword.toLowerCase()))
                    .collect(Collectors.toList());
                });
    }
}
