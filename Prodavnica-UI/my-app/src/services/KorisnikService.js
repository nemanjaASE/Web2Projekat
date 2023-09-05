import api from "../helpers/ConfigHelper";

export const register = async (registerData) => {
  return await api.post(`/korisnik`, registerData, {headers: {"Content-Type":"multipart/form-data"}});
};