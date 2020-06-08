<template>
  <div class="dashboard container-fluid" v-if="$auth.isAuthenticated">
    <!-- NOTE Vaults -->
    <div class="bg px-3 rounded shadow">
      <CreateVaultComp class style="height:1rem" />
      <div class="row my-5 bgImage">
        <div class="col-12 text-center p-0 m-0">
          <h2 class>
            Your Vaults
          </h2>
        </div>
      </div>
      <div class="row">
        <VaultComp v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>

    <hr class="bg-info mt-5 mb-0" />

    <!-- NOTE Create keep -->
    <CreateKeepComp class="justify-content-end mr-5 pr-2" style="height: 3rem" />

    <!-- NOTE Private keeps -->
    <div class="row">
      <div class="col-12 text-center p-0 m-0">
        <h2>Your Keeps</h2>
      </div>
    </div>
    <!-- TODO setup mounted for private and public keeps & insert v-if="this.keepData.isPrivate == true" in row -->
    <div class="row mt-3">
      <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
    </div>
    <!-- NOTE Public keeps -->
    <!-- <div class="row">
      <div class="col-12 text-center">
        <h2>Your Keeps</h2>
        <hr class="w-50 bg-danger mb-5" />
    <!- TODO setup mounted for private and public keeps & insert  v-if="keep.isPrivate == false" in row-->
    <!-- <div class="row mt-3">
          <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
        </div>
      </div>
    </div>-->
  </div>
</template>

// TODO delete keep & Vault
<script>
import CreateVaultComp from "../components/CreateVaultComp.vue";
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
  components: { KeepComp, CreateKeepComp, VaultComp, CreateVaultComp }
};
</script>

<style scoped>
.bg{
  background: rgb(131,58,180);
background: linear-gradient(90deg, rgba(131,58,180,1) 0%, rgba(253,29,29,1) 50%, rgba(252,176,69,1) 100%);
height: 100%;
width: 100%;
}
</style>
