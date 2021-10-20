import {NativeStackScreenProps} from "@react-navigation/native-stack"
import React, {useEffect, useState} from "react"
import {Button, Colors, Text, TextField, View} from "react-native-ui-lib"
import {RootStackParamList} from "../RootStackParamsList"

type restaurantLoginProps = NativeStackScreenProps<RootStackParamList, "RestaurantLoginRegistration">

export const RestaurantLoginRegistration = ({navigation}: restaurantLoginProps) => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")

  const [emailError, setEmailError] = useState("")
  const [passwordError, setPasswordError] = useState("")

  const [emailBlur, setEmailBlur] = useState(false)
  const [passwordBlur, setPasswordBlur] = useState(false)

  const login = () => {
    console.log(email)
    console.log(password)
  }

  const onBlurEmail = () => {
    setEmailBlur(true)
  }

  const onBlurPassword = () => {
    setPasswordBlur(true)
  }

  const navigateToRegistration = () => {
    navigation.navigate("RestaurantRegistration")
  }

  useEffect(() => {
    setEmailError(!email.includes("@") ? "Invalid email" : "")
    setPasswordError(!password ? "Invalid password" : "")
  }, [email, password])

  return (
    <>
      <View flexG center marginT-s4>
        <Text blue40 text20L marginB-s10>
          Restaurant login
        </Text>
        <View marginB-s4 width={320}>
          <View marginB-s5>
            <TextField
              autoCapitalize="none"
              underlineColor={Colors.blue60}
              placeholder="email"
              value={email}
              error={(emailBlur && emailError) || ""}
              onChangeText={setEmail}
              onBlur={onBlurEmail}
            />
          </View>
          <TextField
            autoCapitalize="none"
            underlineColor={Colors.blue60}
            placeholder="password"
            value={password}
            error={(passwordBlur && passwordError) || ""}
            onChangeText={setPassword}
            onBlur={onBlurPassword}
          />
        </View>
        <Button bg-blue50 black label="Login" onPress={login} />
      </View>
      <View center row marginB-s10>
        <Text margin-s2 grey20>
          Not registered yet? Do it now!
        </Text>
        <Button bg-grey50 black label="Register" onPress={navigateToRegistration} />
      </View>
    </>
  )
}