<template>
  <div class="dashboard container-fluid" v-if="$auth.isAuthenticated">
    <h1 class="text-center mt-2">WELCOME TO THE DASHBOARD</h1>

    <!-- NOTE Vaults -->
    <div class="row">
      <div class="col-12 text-center">
        <h2>Your Vaults</h2>
        <hr class="w-50 bg-danger" />
        <!-- TODO vaults draw here -->
        <VaultComp v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>

    <hr class="bg-info mt-5" />
    
<!-- NOTE Create keep -->
    <CreateKeepComp />

    <!-- NOTE Private keeps -->
    <div class="row">
      <div class="col-12 text-center">
        <h2>Your Private Keeps</h2>
        <hr class="w-50 bg-danger" />
        <!-- <div v-if="this.keepData.isPrivate == true"> -->
        <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
        <!-- </div> -->
      </div>
    </div>

    <hr class="bg-info my-5" />

    <!-- NOTE Public keeps -->
    <div class="row">
      <div class="col-12 text-center">
        <h2>Your Public Keeps</h2>
        <hr class="w-50 bg-danger" />
        <!-- <div v-if="keep.isPrivate == false"> -->
        <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
        <!-- </div> -->
      </div>
    </div>
  </div>
</template>

// TODO delete keep & Vault
<script>
import VaultComp from "../components/VaultComp.vue";
import CreateKeepComp from "../components/CreateKeepComp.vue";
import KeepComp from "../components/KeepComp.vue";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  components: { KeepComp, CreateKeepComp, VaultComp }
};
</script>

<style></style>
