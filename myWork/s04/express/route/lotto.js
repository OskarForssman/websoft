/**
 * Route for today.
 */
"use strict";

var express = require("express");
var router  = express.Router();

router.get("/", (req, res) => {

 let data={};
data.lotonumb=[]
for (var i=0;i<7;i++){
    data.lotonumb[i]=Math.floor(Math.random() * 35)+1; 
} 

data.lotonumb.sort(function(a, b){return a-b});

res.render("lotto", data);
    
});

module.exports = router;
