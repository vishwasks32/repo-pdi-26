package com.cloudthat;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Library {

    private List<Book> books;

    public Library() {
        this.books = new ArrayList<Book>();;
    }

    public void  addBook(Book book){
        books.add(book);
    }

    public List<Book> getAvailableBooks(){
        return books.stream()
                .filter(Book::isAvaliable)
                .collect(Collectors.toList());
    }
}
