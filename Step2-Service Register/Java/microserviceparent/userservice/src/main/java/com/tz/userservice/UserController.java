package com.tz.userservice;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/user")
public class UserController {

    @RequestMapping("/getall")
    public List<User> getAll(){
        ArrayList<User> list=new ArrayList<>();
        User user1=new User();
        user1.setAge(10);
        user1.setName("小明");
        user1.setDeleted(false);

        User user2=new User();
        user2.setAge(12);
        user2.setName("小红");
        user2.setDeleted(true);

        list.add(user1);
        list.add(user2);
        return list;
    }
}
