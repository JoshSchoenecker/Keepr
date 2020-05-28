<template>
  <div class="dashboard container-fluid" v-if="$auth.isAuthenticated">
    <!-- NOTE Vaults -->

    <CreateVaultComp style="height:1rem" />
    <div class="row my-5">
      <div class="col-12 text-center">
        <h2 class>
          Your Vaults
          <hr class="w-50 bg-danger" />
        </h2>
      </div>
    </div>
    <div class="row">
      <VaultComp v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
    </div>

    <hr class="bg-info mt-5 mb-0" />

    <!-- NOTE Create keep -->
    <CreateKeepComp class="justify-content-end mr-5 pr-2" style="height: 3rem" />

    <!-- NOTE Private keeps -->
    <div class="row">
      <div class="col-12 text-center">
        <h2>Your Keeps</h2>
        <hr class="w-50 bg-danger mb-5" />
      </div>
    </div>
    <!-- TODO setup mounted for private and public keeps & insert v-if="this.keepData.isPrivate == true" in row -->
    <div class="row mt-3">
      <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
    </div>

    <hr class="bg-info my-5" />

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

<style></style>
