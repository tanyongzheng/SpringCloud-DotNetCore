package com.tz.orderservice;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/order")
public class OrderController {

    @Autowired
    private UserService userService;

    @RequestMapping("/getalluser")
    public List<User> getAllUser(){
        return userService.getAll();
    }

    @RequestMapping("/getuserserviceport")
    public String getUserServicePort(){
        return userService.getPort();
    }
}
