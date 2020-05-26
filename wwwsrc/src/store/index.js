import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true,
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    keeps: [],
    vaults: []
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setVaults(state, vaults){
      state.vaults = vaults;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    // NOTE Keep Actions
    async getKeeps({ commit }) {
      try {
        let res = await api.get("keeps");
        console.log("getKeeps from Store", res.data);

        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error, "failed to getKeeps from Store");
      }
    },
    async getUserKeeps({ commit }) {
      try {
        let res = await api.get("/keeps/user");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error, "failed to getUserKeeps from Store");
      }
    },
    async createKeep({ dispatch }, newKeep) {
      try {
        let res = await api.post("keeps", newKeep);
        dispatch("getkeeps");
      } catch (error) {
        console.error(error, "failed to createKeep from store");
      }
    },
    async deleteKeep({commit, dispatch}, keepId) {
      try {
        window.location.reload();
        await api.delete("keeps/" + keepId);
      } catch (error) {
        console.error(error, "failed to deleteKeep from Store");
      }
    },

    // NOTE Vault Actions
    async getUserVaults({ commit }) {
      try {
        let res = await api.get("/vaults/user");
        commit("setVaults", res.data);
      } catch (error) {
        console.error(error, "failed to getUserVaults from Store");
      }
    },
  },
});
