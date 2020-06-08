<template>
  <div class="keep col-sm-10 col-lg-4">
    <!--NOTE Keep Card -->
    <div class="card promoting-card m-1" style="box-shadow: 1px 1px 10px #f57a007a">
      <!-- dropdown toggle options -->
      <div class="row">
        <div class="col-6" v-if="$auth.user">
          <div class="dropdown show">
            <button
              class="bg-transparent border-0"
              href="#"
              role="button"
              id="dropdownMenuLink"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >
              <i class="fas fa-ellipsis-h"></i>
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
              <button
                v-if="$auth.user.sub == keepData.userId && keepData.isPrivate != false"
                class="btn text-danger btn-sm ml-4"
                style="font-size: 1.1rem"
                @click="deleteKeep()"
                data-toggle="tooltip"
                data-placement="top"
                title="Delete This Keep"
              >Delete Keep</button>
              <button
                class="btn text-danger btn-sm ml-4"
                style="font-size: 1.1rem"
                @click="removeKeepFromVault()"
                data-toggle="tooltip"
                data-placement="top"
                title="Delete This Keep"
              >Remove From Vault</button>
            </div>
          </div>
        </div>

        <!-- NOTE VaultKeep -->
        <div class="col-6 mt-2" v-if="$auth.user">
          <div class="dropdown">
            <button
              class="btn btn-info dropdown-toggle float-right"
              id="menu1"
              type="button"
              data-toggle="dropdown"
            >
              Add 2 Vault
              <span class="caret"></span>
            </button>
            <ul class="dropdown-menu m-0 p-0" role="menu" aria-labelledby="menu1">
              <li
                v-for="vault in vaults"
                :key="vault.id"
                role="presentation"
                @click="addKeepToVault(vault.id)"
              >
                <a role="menuitem">{{vault.name}}</a>
              </li>
            </ul>
          </div>
        </div>
      </div>

      <!-- Card content -->
      <div class="card-body d-flex flex-row">
        <!-- TODO User Image -->
        <img
          src="https://mdbootstrap.com/img/Photos/Avatars/avatar-8.jpg"
          class="rounded-circle mr-3"
          height="50px"
          width="50px"
          alt="avatar"
        />

        <!-- Content -->
        <div>
          <!-- Title -->
          <h4 class="card-title font-weight-bold mb-2">{{keepData.name}}</h4>
          <!--TODO Created at Date -->
          <p class="card-text">
            <i class="far fa-clock pr-2"></i>createdAt: not implemented
          </p>
        </div>
      </div>

      <!-- Keep image -->
      <div class="view overlay">
        <img class="card-img-top img-fluid" :src="keepData.img" />
      </div>

      <div class="card-body">
        <!-- Keep Description -->
        <h5>{{keepData.description}}</h5>
      </div>

      <div class="row">
        <!-- Keep Buttons -->
        <div class="col-8 text-center mb-1 mx-auto rounded border-0">
          <i
            class="fab fa-kaggle text-info btn disabled border-bottom"
            data-toggle="tooltip"
            data-placement="top"
            title="Save to Vault"
          >
            :
            <span class="text-danger">{{keepData.keeps}}</span>
          </i>
          <!-- TODO Keep Shares (not implemented) -->
          <i
            class="fas fa-share-square text-info btn disabled border-bottom"
            data-toggle="tooltip"
            data-placement="top"
            title="Share this Keep"
          >
            :
            <span class="text-danger">{{keepData.shares}}</span>
          </i>

          <!-- IsPrivate icons  -->
          <a
            class="fas fa-lock-open text-danger"
            data-toggle="tooltip"
            data-placement="top"
            title="This is a Public Keep!"
            v-show="keepData.isPrivate == false"
          >Public</a>
          <a
            class="fas fa-lock text-info"
            data-toggle="tooltip"
            data-placement="top"
            title="This is a Private Keep!"
            v-show="keepData.isPrivate == true"
          >Private</a>
        </div>
        <!-- NOTE view/like keep -->
        <div class="col-4">
          <i
            class="fas fa-heart text-info btn border shadow-sm"
            @click="viewKeep()"
            data-toggle="tooltip"
            data-placement="top"
            title="I like it"
          >
            :
            <span class="text-danger">{{keepData.views}}</span>
          </i>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    activeVault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    removeKeepFromVault() {
      this.keepData.keeps -= 1;
      this.$store.dispatch("editKeep", this.keepData);
      console.log(this.keepData);

      this.$store.dispatch("removeKeepFromVault", this.keepData.vaultKeepId);
    },
    viewKeep() {
      this.keepData.views += 1;
      this.$store.dispatch("editKeep", this.keepData);
    },
    addKeepToVault(vaultId) {
      this.keepData.keeps += 1;
      this.$store.dispatch("editKeep", this.keepData);
      console.log(this.keepData);
      let keepId = this.keepData.id;
      let userId = this.keepData.userId;
      let vaultKeep = { vaultId, keepId, userId };
      this.$store.dispatch("addKeepToVault", vaultKeep);
    },
    deleteKeep() {
      Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
      }).then(result => {
        if (result.value) {
          Swal.fire("Deleted!", "Your Keep has been deleted.", "success");
          this.$store.dispatch("deleteKeep", this.keepData.id);
        }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>