package com.cloudthat.addressbookv2.controllers;

import com.cloudthat.addressbookv2.config.AppConfig;
import com.cloudthat.addressbookv2.dtos.ContactModel;
import com.cloudthat.addressbookv2.models.Gender;
import com.cloudthat.addressbookv2.services.ContactService;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.webmvc.test.autoconfigure.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.context.bean.override.mockito.MockitoBean;
import org.springframework.test.web.servlet.MockMvc;
import tools.jackson.databind.ObjectMapper;



import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.jsonPath;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(ContactController.class)
public class ContactControllerTest {

//    @MockitoBean
//    private ContactService contactService;
//
//    @Autowired
//    private MockMvc mockMvc;
//
//    @MockitoBean
//    private AppConfig appConfig;
//
//    @Autowired
//    private ObjectMapper objectMapper;
//
//    @Test
//    void shouldCreateContactAndReturn201() throws Exception{
//        // Step 1: Arrange
//        ContactModel inputContact = new ContactModel(null,"Vishwas Singh", "vishwas@cloudthat.com", null,null,null,null,null,null);
//
//
//        ContactModel savedContact = new ContactModel(1L,"Vishwas Singh", "vishwas@cloudthat.com", null,null,null,null,null,null);
//
//        when(appConfig.getSupportEmail()).thenReturn("vishwas@cloudthat.com");
//        when(contactService.createContact(inputContact)).thenReturn(savedContact);
//
//        mockMvc.perform(post("/api/v1/contacts")
//                .contentType(MediaType.APPLICATION_JSON)
//                .content(objectMapper.writeValueAsString(inputContact)))
//                .andExpect(status().isCreated())
//                .andExpect(jsonPath("$.success").value(true))
//                .andExpect(jsonPath("$.message").value("Contact created successfully"))
//                .andExpect(jsonPath("$.data.id").value(1L))
//                .andExpect(jsonPath("$.data.contactName").value("Vishwas Singh"));
//    }


}
