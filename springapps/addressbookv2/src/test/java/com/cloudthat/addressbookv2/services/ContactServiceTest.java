package com.cloudthat.addressbookv2.services;

import com.cloudthat.addressbookv2.dtos.ContactModel;
import com.cloudthat.addressbookv2.mappers.ContactMapper;
import com.cloudthat.addressbookv2.models.Contact;
import com.cloudthat.addressbookv2.repositories.ContactRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.test.context.bean.override.mockito.MockitoBean;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.AssertionsKt.assertNotNull;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;


@ExtendWith(MockitoExtension.class)
public class ContactServiceTest {

//    @Mock
//    private ContactRepository contactRepository;
//
//    @MockitoBean
//    private ContactMapper contactMapper;
//
//    @InjectMocks
//    private ContactService contactService;

//    @Test
//    void shouldSaveContactAndReturnResponseRecord(){
//        ContactModel inputContact = new ContactModel(null,"Vishwas Singh", "vishwas@cloudthat.com", null,null,null,null,null,null);
//
//        Contact contact = new Contact();
//        contact.setId(1L);
//        contact.setContactName("Vishwas Singh");
//        contact.setEmailId("vishwas@cloudthat.com");
//
//        when(contactMapper.toContact(any(ContactModel.class))).thenReturn(contact);
//        when(contactRepository.save(any(Contact.class))).thenReturn(contact);
//
//        ContactModel result = contactService.createContact(inputContact);
//
//        assertNotNull(result);
//        assertEquals(1L,result.id());
//        assertEquals("Vishwas Singh", result.contactName());
//
//        verify(contactRepository, times(1)).save(any(Contact.class));
//    }
}
