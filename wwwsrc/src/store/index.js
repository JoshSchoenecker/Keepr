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
    vaults: [],
    vaultKeeps: [],
    activeVault: {},
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps;
    },
    setActiveVault(state, vault) {
      state.activeVault = vault;
    },
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
        await api.post("keeps", newKeep);
        dispatch("getKeeps");
      } catch (error) {
        console.error(error, "failed to createKeep from store");
      }
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        await api.delete("keeps/" + keepId);
        dispatch("getKeeps");
      } catch (error) {
        console.error(error, "failed to deleteKeep from Store");
      }
    },
    // NOTE Put Request
    async editKeep({ dispatch }, keepData) {
      try {
        console.log("editKeep:", keepData);

        await api.put("keeps/" + keepData.id, keepData);
        dispatch("getKeeps");
      } catch (error) {
        console.error(error, "failed to addKeepsToKeep from Store");
      }
    },

    // NOTE Vault Actions
    // NOTE Post Request
    async createVault({ dispatch }, newVault) {
      try {
        await api.post("vaults", newVault);
        dispatch("getUserVaults");
      } catch (error) {
        console.error(error, "failed to createVault from Store");
      }
    },
    // NOTE Get Request
    async getUserVaults({ commit }) {
      try {
        let res = await api.get("/vaults/user");
        commit("setVaults", res.data);
      } catch (error) {
        console.error(error, "failed to getUserVaults from Store");
      }
    },
    async getVault({ commit }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId);
        if (res.data.id) {
          commit("setActiveVault", res.data);
        }
      } catch (error) {
        console.error(error, "getVault failed from Store");
      }
    },
    // NOTE Delete Request
    async deleteVault({ dispatch }, vaultId) {
      try {
        await api.delete("vaults/" + vaultId);
        dispatch("getUserVaults");
      } catch (error) {
        console.error(error, "failed to deleteVault from Store");
      }
    },

    // NOTE VaultKeep Requests
    // NOTE Post Request
    async addKeepToVault({ dispatch }, vaultKeep) {
      try {
        let res = await api.post("vaultkeeps/", vaultKeep);
        dispatch("getKeepsOnVaults", res.data.vaultId);
      } catch (error) {
        console.error(error, "failed addKeepToVault from Store");
      }
    },

    // NOTE Get Request PATH: `vaults/ ${vaultId}/ keeps` did not work.
    async getKeepsOnVaults({ commit }, vaultId) {
      try {
        console.log("vaultId",vaultId);
        let res = await api.get("vaults/" + vaultId + "/keeps");
        console.log(res.data);
        
        commit("setVaultKeeps", res.data);
      } catch (error) {
        console.error(error, "failed to getKeepsOnVaults from Store");
      }
    },
  },
});
