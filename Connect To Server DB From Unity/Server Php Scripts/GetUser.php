<?php

  $Servername = "ServerName";
  $Username = "UserName"; 
  $Password = "Password";
  $DataBaseName = "DatabaseName";
  $NumberOfUsers = array();

  // Create connection
  $conn = new mysqli($Servername, $Username, $Password,$DataBaseName);
  
  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }

      $Query = "SELECT * FROM TableName";
      $Result = mysqli_query($conn,$Query);
      $QueryRow = mysqli_num_rows($Result);

      if ($QueryRow > 0) {
        while($User = mysqli_fetch_assoc($Result)) {
          $NumberOfUsers[] = $User;
        }
        echo json_encode($NumberOfUsers);
      } else {
        echo "Not Found User";
      }
      $conn->close();
?>